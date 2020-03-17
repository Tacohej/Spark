using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitPanel : MonoBehaviour
{
    [SerializeField]
    private Unit unit = default;

    private Image healthImage;
    private Image manaImage;
    private Text statText;

    void Start ()
    {
        healthImage = transform.Find("Health").GetComponent<Image>();
        manaImage = transform.Find("Mana").GetComponent<Image>();
        statText = transform.Find("Stats").GetComponent<Text>();
    }

    void Update()
    {
        var healthFill = unit.health.Value / (float) unit.health.Max;
        var manaFill = unit.mana.Value / (float) unit.mana.Max;

        healthImage.fillAmount = healthFill;
        manaImage.fillAmount = manaFill;

        string[] stats = {
            $"Stamina: {unit.stamina.Value}",
            $"Strength: {unit.strength.Value}",
            $"Agility: {unit.agility.Value}",
            $"Intelligence: {unit.intelligence.Value}"
        };

        statText.text = string.Join("\n", stats);

    }
}

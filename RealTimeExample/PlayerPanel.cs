using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    [SerializeField]
    private Player player = default;

    private Image healthPanel;
    private Image manaPanel;

    void Start ()
    {
        healthPanel = transform.Find("Health").GetComponent<Image>();
        manaPanel = transform.Find("Mana").GetComponent<Image>();
    }

    void Update()
    {
        var healthFill = player.Health / (float) player.MaxHealth;
        var manaFill = player.Mana / (float) player.MaxMana;

        healthPanel.fillAmount = healthFill;
        manaPanel.fillAmount = manaFill;
    }
}

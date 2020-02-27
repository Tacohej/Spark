using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private Image healthPanel;
    private Image manaPanel;

    void Start ()
    {
        healthPanel = GameObject.Find("Health").GetComponent<Image>();
        manaPanel = GameObject.Find("Mana").GetComponent<Image>();
    }

    void Update()
    {
        var healthFill = player.Health / (float) player.MaxHealth;
        var manaFill = player.Mana / (float) player.MaxMana;

        healthPanel.fillAmount = healthFill;
        manaPanel.fillAmount = manaFill;
    }
}

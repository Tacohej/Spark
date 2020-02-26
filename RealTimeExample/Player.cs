using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

public class Player : MonoBehaviour
{
    [SerializeField] StatModifierValue maxHealthBase;
    [SerializeField] StatModifierValue maxManaBase;
    [SerializeField] StatModifierValue manaRegenBase;
    [SerializeField] StatModifierValue moveSpeedBase;
    [SerializeField] StatModifierValue castSpeedBase;

    private int healthMissing = 0;
    private int manaMissing = 0;
    private float castCooldown = 0;
    private Unit unit;

    void Start ()
    {
        unit = GetComponent<Unit>();

        unit.AddModifier("MaxHealth", maxHealthBase);
        unit.AddModifier("MaxMana", maxManaBase);
        unit.AddModifier("ManaRegen", manaRegenBase);
        unit.AddModifier("MoveSpeed", moveSpeedBase);
        unit.AddModifier("CastSpeed", castSpeedBase);

        InvokeRepeating("UpdateEverySecond", 0, 1.0f);
    }

    public int Health
    {
        get { return unit.GetStat("MaxHealth") - healthMissing; }
    }

    public int Mana
    {
        get { return unit.GetStat("MaxMana") - manaMissing; }
    }

    void UpdateEverySecond ()
    {
        manaMissing = Mathf.Max(unit.GetStat("MaxMana"), manaMissing + unit.GetStat("ManaRegen"));
    }

    void Update ()
    {
        var dt = Time.deltaTime;

        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var direction = new Vector3(horizontal, 0, vertical).normalized;
        transform.Translate(direction * dt * unit.GetStat("MoveSpeed"));

        // attacking
        if (castCooldown < 0)
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("Attack");
                castCooldown = 5;
            }
        }
        else
        {
            castCooldown -= dt * unit.GetStat("CastSpeed");
        }
    }
}

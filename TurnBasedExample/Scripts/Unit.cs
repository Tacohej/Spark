using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

[CreateAssetMenu(menuName="Game/Unit")]
public class Unit : ScriptableObject
{
    public string unitName;

    public bool isHero;

    public enum DamageType
    {
        Physical,
        Magical
    }

    [System.NonSerialized]
    private int health;
    [System.NonSerialized]
    private int initiative;

    [SerializeField]
    private List<Item> items = new List<Item>();

    // Damage Reduction
    public UnitStat Armor = new UnitStat(0);

    // Max Health
    public UnitStat Stamina = new UnitStat(100);

    // Damage
    // Health regeneration
    // Magic Resitance
    public UnitStat Strength = new UnitStat(10);

    // Crit
    // Evation
    // Speed
    // Armor
    public UnitStat Agility = new UnitStat(10);

    // Spell Damage
    // Max Mana
    // Mana reg
    public UnitStat Intelligence = new UnitStat(10);

    public EffectTrigger<EffectDataWithTarget> OnAttackTrigger = new EffectTrigger<EffectDataWithTarget>();
    public EffectTrigger<EffectDataWithTarget> OnKillTrigger = new EffectTrigger<EffectDataWithTarget>();

    public EffectTrigger<EffectDataWithTarget> OnAttackedTrigger = new EffectTrigger<EffectDataWithTarget>();
    public EffectTrigger<EffectDataWithTarget> OnDeathTrigger = new EffectTrigger<EffectDataWithTarget>();

    public TurnBasedStatusEffectManager statusEffectManager = new TurnBasedStatusEffectManager();

    void OnEnable ()
    {
        EquipItems();
        health = Stamina.Value;
        Debug.Log(Stamina.Value);
    }

    public int Health
    {
        get { return health; }
    }

    public override string ToString ()
    {
        return unitName;
    }

    protected void EquipItems ()
    {
        foreach(Item item in items)
        {
            var characterItem = item as EquippableCharacterItem;
            if (characterItem != null)
            {
                characterItem.OnEquip(this);
            }
        }
    }

    public int Initiative { set;get; }

    public bool IsDead ()
    {
        return health <= 0;
    }

    public void Heal (int amount)
    {
        health = Mathf.Clamp(health + amount, 0, Stamina.Value);
    }

    public int ReciveDamage (int rawDamage, DamageType type)
    {
        var damage = 0;

        if (type == DamageType.Physical)
        {
            var reducedDamage = Mathf.Clamp(rawDamage - Armor.Value, 0, rawDamage);
            damage = reducedDamage;
        }

        if (type == DamageType.Magical)
        {
            var reducedDamage = Mathf.Clamp(rawDamage, 0, rawDamage);
        }

        health-= damage;
        return damage;
    }

    public void OnKill ()
    {
        OnKillTrigger.TriggerEffect(new EffectDataWithTarget { caster = this, target = this}); // temp target
    }

    public void OnHit ()
    {
        OnKillTrigger.TriggerEffect(new EffectDataWithTarget { caster = this, target = this}); // temp target
    }
}
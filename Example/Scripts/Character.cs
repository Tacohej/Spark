using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

public class Character : MonoBehaviour
{
    private int health;

    [SerializeField]
    private List<Item> items = new List<Item>();

    public UnitStat Armor = new UnitStat(0);
    public UnitStat Stamina = new UnitStat(100);
    public UnitStat Strength = new UnitStat(10);
    public UnitStat Dexterity = new UnitStat(10);
    public UnitStat Intelligence = new UnitStat(10);

    public EffectTrigger<CombatStateWithTarget> OnKillTrigger = new EffectTrigger<CombatStateWithTarget>();
    public EffectTrigger<CombatStateWithTarget> OnHitTrigger = new EffectTrigger<CombatStateWithTarget>();

    public TurnBasedStatusEffectManager statusEffectManager = new TurnBasedStatusEffectManager();


    void Start ()
    {
        EquipItems();
        health = Stamina.Value;
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

    public void Heal (int amount)
    {
        health = Mathf.Clamp(health + amount, 0, Stamina.Value);
    }

    public void ReciveDamage (int amount)
    {
        var clampedDamage = Mathf.Clamp(amount, 0, amount);
        health-= clampedDamage;
    }

    public void OnKill ()
    {
        OnKillTrigger.TriggerEffect(new CombatStateWithTarget { self = this, target = this}); // temp target
    }

    public void OnHit ()
    {
        OnKillTrigger.TriggerEffect(new CombatStateWithTarget { self = this, target = this}); // temp target
    }
}
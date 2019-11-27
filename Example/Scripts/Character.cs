using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

public abstract class CharacterItem : Item<Character> {}
public class Character : MonoBehaviour
{
    private int health;

    [SerializeField]
    private List<CharacterItem> items = new List<CharacterItem>();

    public UnitStat Armor = new UnitStat(0);
    public UnitStat Stamina = new UnitStat(100);
    public UnitStat Strength = new UnitStat(10);
    public UnitStat Dexterity = new UnitStat(10);
    public UnitStat Intelligence = new UnitStat(10);

    public EffectTrigger<CombatStateWithTarget> OnKillTrigger = new EffectTrigger<CombatStateWithTarget>();

    public void Start ()
    {
        foreach(CharacterItem item in items)
        {
            item.Equip(this);
        }
        health = Stamina.Value;
    }

    public void Heal (int amount)
    {
        health = Mathf.Clamp(health + amount, 0, Stamina.Value);
    }

    public void OnKill ()
    {
        OnKillTrigger.TriggerEffect(new CombatStateWithTarget { self = this, target = this});
    }
}
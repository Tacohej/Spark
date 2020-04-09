using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

namespace RealTimeExample
{
    public class Unit : MonoBehaviour
    {
        public List<UnitItem> items;

        public UnitStat stamina;
        public UnitStat strength;
        public UnitStat agility;
        public UnitStat intelligence;

        public Formula<float> critChance;
        public Formula<float> moveSpeed;
        public Formula<float> manaRegen;

        public ResourceInt health;
        public ResourceInt mana;

        public Unit target;

        public TriggeredEffect<Unit> onAttackEffect = new TriggeredEffect<Unit>();
        public TriggeredEffect onStartEffect = new TriggeredEffect();

        public RealTimeManager<Unit> statusEffectManager;

        void Awake ()
        {
            // health = new ResourceInt(new FormulaInt(stamina).Multiply(10));
            // mana = new ResourceInt(new FormulaInt(intelligence).Multiply(10));

            critChance = new Formula<float>(() => {
                return agility.Value * 0.01f;
            });

            moveSpeed = new Formula<float>(() => {
                return agility.Value * 0.1f;
            });

            manaRegen = new Formula<float>(() => {
                return intelligence.Value * 0.1f;
            });

            statusEffectManager = new RealTimeManager<Unit>(this);

            foreach (UnitItem item in items)
            {
                item.Equip(this);
            }

        }

        void Update ()
        {
            statusEffectManager.Update();
        }

    }
}

using System.Collections.Generic;


namespace Spark
{
    public abstract class StatusEffectManager<T, U> where U : StatusEffect<T>
    {
        protected T unit;
        public readonly Dictionary<string, U> statusEffects = new Dictionary<string, U>();

        public StatusEffectManager(T unit)
        {
            this.unit = unit;
        }

        public void ApplyStatusEffect(U statusEffect)
        {
            U currStatusEffect;
            if (statusEffects.TryGetValue(statusEffect.Name, out currStatusEffect))
            {
                currStatusEffect.AddStack(unit);
            }
            else
            {
                statusEffect.Reset();
                statusEffect.Apply(unit);
                statusEffects[statusEffect.Name] = statusEffect;
            }
        }

        public abstract void Update ();

    }
}
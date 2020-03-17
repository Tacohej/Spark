using UnityEngine;
using System;
using Spark;

[CreateAssetMenu(fileName="BootsOfSpeed", menuName="Game/Item/BootsOfSpeed")]
public class BootsOfSpeed : UnitItem
{
    [SerializeField]
    private StatModifier speedModifier = default;

    private Action<Unit> moveBuffAction;
    private RealTimeStatusEffect<Unit> moveBuff;

    void OnEnable ()
    {
        moveBuff = new RealTimeStatusEffect<Unit>("MoveBuff")
            .WithDuration(3)
            .OnApply((Unit unit) =>
            {
                unit.agility.AddModifier(speedModifier);
            })
            .OnTick((Unit unit) =>
            {
                unit.agility.UpdateModifier(speedModifier, 10);
            })
            .OnExpire((Unit unit) =>
            {
                unit.agility.RemoveModifier(speedModifier);
                Debug.Log("OnExpire");
            });

    }

    public override void Equip(Unit unit)
    {
        moveBuffAction = unit.onAttackEffect.RegisterEffect(target => {
            unit.statusEffectManager.ApplyStatusEffect(moveBuff);
        });
    }

    public override void Unequip(Unit unit)
    {
        unit.onAttackEffect.UnregisterEffect(moveBuffAction);
    }
}
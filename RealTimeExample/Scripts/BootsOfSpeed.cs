using UnityEngine;
using Spark;

[CreateAssetMenu(fileName="BootsOfSpeed", menuName="Game/Item/BootsOfSpeed")]
public class BootsOfSpeed : Item
{
    [SerializeField]
    private StatModifier speedModifier = default;

    [SerializeField]
    private int damage = 30;

    private RealTimeStatusEffect moveBuff;

    void OnEnable ()
    {
        moveBuff = new RealTimeStatusEffect("MoveBuff")
            .WithDuration(3)
            .OnApply((Unit unit) =>
            {
                Debug.Log("OnApply");
            })
            .OnTick((Unit unit) =>
            {
                Debug.Log("OnTick");
            })
            .OnExpire((Unit Unit) =>
            {
                Debug.Log("OnExpire");
            });
    }

    public override void OnEquip(Unit unit)
    {
        var player = unit as Player;
        player.AddModifier(speedModifier);

        player.AddTriggeredEffect("OnAttack", () =>
        {
            player.ApplyStatusEffect(moveBuff);
        });
    }

    public override void OnUnequip(Unit unit)
    {
        return;
    }
}
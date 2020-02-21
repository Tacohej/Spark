using UnityEngine;


[CreateAssetMenu(menuName="Game/CombatState/ResolveInitiativeState")]
public class ResolveInitiativeState : CombatState
{
    [SerializeField]
    private CombatState resolveMeleeAttackState;

    public void UpdateInitiative (Unit unit, Dungeon dungeon)
    {
        unit.Initiative = unit.Initiative + unit.Agility.Value;
        if (unit.Initiative >= 100)
        {
            unit.Initiative -= 100;
            dungeon.AddUnitToQueue(unit);
        }
    }

    public override CombatState Execute(Dungeon dungeon)
    {
        var currRoom = dungeon.GetCurrentRoom();
        var monsters = currRoom.monsters;
        var heroes = dungeon.heroes;

        while (true)
        {
            if (dungeon.HasQueuedUnits())
            {
                return resolveMeleeAttackState;
            }

            for (int i = 0; i < heroes.Count; i++)
            {
                UpdateInitiative(heroes[i], dungeon);
            }

            for (int i = 0; i < monsters.Count; i++)
            {
                UpdateInitiative(monsters[i], dungeon);
            }
        }
    }
}
using UnityEngine;

[CreateAssetMenu(menuName="Game/CombatState/ResolutionState")]
public class ResolutionState : CombatState
{
    public CombatState GameOverState;
    public CombatState ResolveInitiativeState;
    public CombatState DungeonFinishedState;

    public override CombatState Execute(Dungeon dungeon)
    {
        if (dungeon.AllHeroesAreDead())
        {
            return GameOverState;
        }

        if (dungeon.AllMonstersInCurrentRoomAreDead() && dungeon.HasRoomsLeft())
        {
            return ResolveInitiativeState;
        }

        return DungeonFinishedState;
    }
}
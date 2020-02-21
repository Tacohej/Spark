using UnityEngine;

[CreateAssetMenu(menuName="Game/CombatState/FinishedDungeon")]
public class FinishedDungeon : CombatState
{
    public override CombatState Execute(Dungeon dungeon)
    {
        Debug.Log("Finished Dungeon");
        return null;
    }
}
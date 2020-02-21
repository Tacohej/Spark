using UnityEngine;

[CreateAssetMenu(menuName="Game/CombatState/GameOverState")]
public class GameOverState : CombatState
{
    public override CombatState Execute(Dungeon dungeon)
    {
        Debug.Log("Game Over");
        return null;
    }
}
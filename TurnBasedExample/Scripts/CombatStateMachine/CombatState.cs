using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatState : ScriptableObject
{
    public abstract CombatState Execute(Dungeon dungeon);
}

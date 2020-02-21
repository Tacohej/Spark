using UnityEngine;
using System.Collections.Generic;

// rework to group?
[System.Serializable]
public class Room
{
    public List<Unit> monsters = new List<Unit>();

    public Unit GetDefendingUnit () // TEMP
    {
        return monsters[0];
    }
}
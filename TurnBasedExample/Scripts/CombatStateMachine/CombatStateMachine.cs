using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStateMachine : MonoBehaviour
{
    public CombatState initialState;
    public Dungeon dungeon;

    private CombatState currentState;

    void Start ()
    {
        currentState = initialState;
    }

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentState = currentState.Execute(dungeon);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

public class Player : MonoBehaviour
{
    public int baseStrength = 5;

    public Unit unit;

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var StrengthTotal = unit.GetStatTotal<Strength>(baseStrength);
            Debug.Log("StrengthTotal: " + StrengthTotal);
        }
    }
}

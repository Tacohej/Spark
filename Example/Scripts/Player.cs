using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

public class Player : MonoBehaviour
{
    public int baseHealth = 100;
    public int baseStrength = 5;
    public int baseAgility = 7;

    public Unit unit;

    void Start ()
    {
        unit.SetBaseStat<Strength>(baseStrength);
        unit.SetBaseStat<Agility>(baseAgility);
        unit.SetBaseStat<Health>(baseHealth);
    }

    public void Heal ()
    {
        Debug.Log("Heal");
    }

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var strenth = unit.GetStatTotal<Strength>();
            Debug.Log(strenth);
        }

        if (Input.GetMouseButtonDown(1))
        {
            unit.TriggerEffects<OnHit>();
            var strenth = unit.GetStatTotal<Strength>();
            Debug.Log(strenth);
        }
    }
}

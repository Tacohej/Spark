using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

[CreateAssetMenu(menuName="Game/MyUnit")]
public class SparkUnit : Unit<SparkUnit>
{
    public void SayHello ()
    {
        Debug.Log("Say Hello");
    }
}
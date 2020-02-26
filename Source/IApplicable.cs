using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spark;

public interface IApplicable
{
    void OnApply (Unit unit);
    void OnExpire (Unit unit);
    void OnTick (Unit unit);
}

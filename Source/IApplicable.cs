using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IApplicable<T>
{
    void OnApply (T unit);
    void OnExpire (T unit);
    void OnTick (T unit);
}

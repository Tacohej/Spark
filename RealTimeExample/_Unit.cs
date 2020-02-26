using System.Collections.Generic;

[System.Serializable]
public enum _unitStatModifierValueType
{
    flat,
    multiplier
}
[System.Serializable]
public class _unitStatModifierValue
{
    public int value;
    public _unitStatModifierValueType valueType;
}

[System.Serializable]
public class _unitStatModifier
{
    public string type;
    public _unitStatModifierValue value;
}
[System.Serializable]
public class _unitStat
{
    public void AddModifier ()
    {

    }
}
[System.Serializable]
public class _effectModifierValue
{

}
[System.Serializable]
public class _effectModifier
{
    public string type;
    public _effectModifierValue value;
}

public class _item<T>
{
    public List<_unitStatModifier> statModifiers;
    public List<_effectModifier> effectModifiers;
    // public List<_effectTrigger> effectTriggers;

    public void OnEquip(_unit<T> unit)
    {
        foreach (_unitStatModifier modifier in statModifiers)
        {
            // unit.AddModifier(modifier);
        }
        foreach (_effectModifier modifier in effectModifiers)
        {
            // unit.AddTriggeredEffect(modifier);
        }

        // foreach (_effectModifier)
    }
}
[System.Serializable]
public class _effectTrigger<T>
{
    public delegate void OnTriggerEffect(T unit);
    public event OnTriggerEffect triggerEffect;

    public void TriggerEffect (T unit)
    {
        triggerEffect?.Invoke(unit);
    }

    public void RegisterTriggeredEffect  (OnTriggerEffect effect) 
    {
        triggerEffect += effect;
    }
}


public class _unit<T>
{
    public string test = "hello";
    public List<_item<T>> items;
    public Dictionary<string, _unitStatModifierValue> unitStats;
    public Dictionary<string, _effectTrigger<T>> effectTrigger;

    public void AddModifier (_unitStatModifier statModifier)
    {
        unitStats.Add(statModifier.type, statModifier.value);
    }

    public void AddTriggeredEffect (_effectModifier effectModifier)
    {
        
    }

    public void EquipItem (_item<T> item)
    {
        item.OnEquip(this);
    }
}

public class _combatState
{

}

[System.Serializable]
public class _item1 : _item<_combatState>
{

}
[System.Serializable]
public class _unit1 : _unit<_combatState>
{
    public new List<_item1> items = new List<_item1>();
}



// using System.Collections.Generic;

// public enum _unitStatModifierValueType
// {
//     flat,
//     multiplier
// }

// public class _unitStatModifierValue
// {
//     public int value;
//     public _unitStatModifierValueType valueType;
// }

// public class _unitStatModifier
// {
//     public string type;
//     public _unitStatModifierValue value;
// }

// public class _unitStat
// {
//     public void AddModifier ()
//     {

//     }
// }

// public class _effectModifierValue
// {

// }

// public class _effectModifier
// {
//     public string type;
//     public _effectModifierValue value;
// }

// public class _item
// {
//     public List<_unitStatModifier> statModifiers;
//     public List<_effectModifier> effectModifiers;
//     // public List<_effectTrigger> effectTriggers;

//     public void OnEquip (_unit unit)
//     {
//         foreach (_unitStatModifier modifier in statModifiers)
//         {
//             unit.AddModifier(modifier);
//         }
//         foreach (_effectModifier modifier in effectModifiers)
//         {
//             unit.AddTriggeredEffect(modifier);
//         }

//         // foreach (_effectModifier)
//     }
// }

// public class _effectTrigger
// {
//     public delegate void OnTriggerEffect(_unit unit);
//     public event OnTriggerEffect triggerEffect;

//     public void TriggerEffect (_unit unit)
//     {
//         triggerEffect?.Invoke(unit);
//     }

//     public void RegisterTriggeredEffect  (OnTriggerEffect effect) 
//     {
//         triggerEffect += effect;
//     }
// }

// public class _statusEffectManager
// {

// }


// public class _unit
// {
//     public List<_item> items;
//     public Dictionary<string, _unitStatModifierValue> unitStats;
//     public Dictionary<string, _effectTrigger> effectTrigger;

//     public void AddModifier (_unitStatModifier statModifier)
//     {
//         unitStats.Add(statModifier.type, statModifier.value);
//     }

//     public void AddTriggeredEffect (_effectModifier effectModifier)
//     {
        
//     }

//     public void EquipItem (_item item)
//     {
//         item.OnEquip(this);
//     }
// }


// Problem 1: Hur anropar jag funktioner från callback
    // går det att göra med UnityEvents?
    // skicka med monobehavior så man kan köra getComponent
    // registrera funktioner i unit på något sätt

// Problem 2: Hur hanterar jag en update function där en tar time och andra inte
    // hantera allt med float

// Problem 3: Hur känner jag till items från effect
    // skicka med vid reg i item
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    [CreateAssetMenu(menuName="ItemEffectSystem/TriggeredEffect")]
    public class TriggeredEffect : ScriptableObject
    {
        public Trigger trigger;
        public Reaction reaction;
    }
}

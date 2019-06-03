using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spark
{
    [CreateAssetMenu(menuName="Spark/TriggeredEffect")]
    public class TriggeredEffect : ScriptableObject
    {
        public List<Condition> conditions;
        public Trigger trigger;
        public Reaction reaction;

        public bool ConditionsAreMet (StateManager stateManager)
        {
            for (int i = 0; i < conditions.Count; i++)
            {
                Condition con = conditions[i];
                if (!con.IsMet(stateManager))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

using UnityEngine;

[CreateAssetMenu(menuName="Spark/Custom/Triggers/OnAttack", fileName="Trigger_OnAttack")]
public class OnAttack : Spark.Trigger
{
    public override string GetTriggerName()
    {
        return "OnAttack";
    }
}

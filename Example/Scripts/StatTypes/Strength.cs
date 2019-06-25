using UnityEngine;

[CreateAssetMenu(menuName="Spark/Custom/StatType/Strength", fileName="StatType_Strength")]
public class Strength : Spark.StatType
{
    public override string GetStatTypeName ()
    {
        return "Strength";
    }
}

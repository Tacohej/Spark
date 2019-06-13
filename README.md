# Spark
⚡️ Simple effect system for Unity

# TODO:
* Register effect and item state in EffectManager, use static sting constants:

````
class EffectManager ()
{
  public static string EFFECT = "SPARK_STATE_CONSTANT_EFFECT";
  public static string ITEM = "SPARK_STATE_CONSTANT_ITEM";
  
  ...
  
  public void TriggerEffects<T> (StateManager stateManager)
  {
    foreach(Item item in this.items)
    {
      stateManager.RegisterState(ITEM, item);
      foreach(Effect effect in item.effects)
      {
        stateManager.RegisterState(EFFECT, effect);
      }
    }
  }
}

```` 

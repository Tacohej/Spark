using UnityEngine;
using UnityEngine.Events;

namespace Spark
{
    public abstract class EventData { }
    public class UnityDataEvent : UnityEvent<EventData> { }
}
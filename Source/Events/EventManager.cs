using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Spark
{
    [CreateAssetMenu(menuName = "Spark/EventManager")]
    public class EventManager : ScriptableObject
    {
        [System.NonSerialized]
        private Dictionary<string, UnityEvent> events = new Dictionary<string, UnityEvent>();
        [System.NonSerialized]
        private Dictionary<string, UnityDataEvent> dataEvents = new Dictionary<string, UnityDataEvent>();

        public void StartListening(string eventName, UnityAction listener)
        {
            UnityEvent e = null;
            if (events.TryGetValue(eventName, out e))
            {
                e.AddListener(listener);
            }
            else
            {
                e = new UnityEvent();
                e.AddListener(listener);
                events.Add(eventName, e);
            }
        }

        public void StartListening (string eventName, UnityAction<EventData> listener)
        {
            UnityDataEvent e = null;
            if (dataEvents.TryGetValue(eventName, out e))
            {
                e.AddListener(listener);
            }
            else
            {
                e = new UnityDataEvent();
                e.AddListener(listener);
                dataEvents.Add(eventName, e);
            }
        }

    public void StopListening(string eventName, UnityAction listener)
    {
            UnityEvent e = null;
            if (events.TryGetValue(eventName, out e))
            {
                e.RemoveListener(listener);
            }
    }

    public void StopListening (string eventName, UnityAction<EventData> listener)
        {
            UnityDataEvent e = null;
            if (dataEvents.TryGetValue(eventName, out e))
            {
                e.RemoveListener(listener);
            }
        }

    public void TriggerEvent(string eventName)
    {
            UnityEvent e = null;
            if (events.TryGetValue(eventName, out e))
            {
                e.Invoke();
            }
    }

        public void TriggerEvent (string eventName, EventData data)
        {
            UnityDataEvent e = null;
            if (dataEvents.TryGetValue(eventName, out e))
            {
                e.Invoke(data);
            }
        }
    }
}

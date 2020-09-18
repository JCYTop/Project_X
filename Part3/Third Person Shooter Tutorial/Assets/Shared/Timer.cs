using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private class TimeEvent
    {
        public float TimeToExecute;
        public Callback Method;
    }

    private List<TimeEvent> events;

    public delegate void Callback();

    private void Awake()
    {
        events = new List<TimeEvent>();
    }

    public void Add(Callback method, float inSeConds)
    {
        events.Add(new TimeEvent()
        {
            Method = method,
            TimeToExecute = Time.time + inSeConds,
        });
    }

    private void Update()
    {
        if (events.Count == 0)
            return;
        for (int i = events.Count - 1; i >= 0; i--)
        {
            var timeEvent = events[i];
            if (timeEvent.TimeToExecute <= Time.time)
            {
                timeEvent.Method();
                events.Remove(timeEvent);
            }
        }
    }
}
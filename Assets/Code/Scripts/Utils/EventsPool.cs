using System;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EventsPool : Singleton<EventsPool>
{
    private Dictionary<Type, Delegate> eventsDictionary;

    protected override void Awake()
    {
        base.Awake();
        eventsDictionary = new Dictionary<Type, Delegate>();
        SceneManager.sceneUnloaded += OnChangeScene;
    }
    public void AddListener(Type eventType, Delegate listener)
    {
        Delegate thisEvent;
        if (eventsDictionary == null)
        {
            eventsDictionary = new Dictionary<Type, Delegate>();
        }

        if (eventsDictionary.TryGetValue(eventType, out thisEvent))
        {
            eventsDictionary[eventType] = Delegate.Combine(thisEvent, listener);
        }
        else
        {
            eventsDictionary[eventType] = listener;
        }
    }

    public void RemoveListener(Type eventType, Delegate listener)
    {
        if (eventsDictionary == null) return;
        Delegate thisEvent;
        if (eventsDictionary.TryGetValue(eventType, out thisEvent))
        {
            eventsDictionary[eventType] = Delegate.Remove(thisEvent, listener);
        }
    }

    public void InvokeEvent(Type eventType, params object[] args)
    {
        Delegate thisEvent;
        if (eventsDictionary.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.DynamicInvoke(args);
        }
    }

    private void OnChangeScene(Scene sc)
    {
        eventsDictionary.Clear();
    }
}
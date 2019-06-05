using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action<ActionKey>
{
    Dictionary<ActionKey, System.Action> action = new Dictionary<ActionKey, System.Action>();

    public void Add (ActionKey key, System.Action func)
    {
        if (!action.ContainsKey(key))
            action.Add(key, func);
    }

    public void Remove(ActionKey key)
    {
        if (action.ContainsKey(key))
            action.Remove(key);
    }

    public void Clear()
    {
        action.Clear();
    }

    public void Call (ActionKey key)
    {
        if (action.ContainsKey(key) && action[key] != null)
            action[key]();
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void Run()
    {

    }
}

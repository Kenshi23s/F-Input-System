using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public struct PawnAction
{
    public PawnAction(string name, UnityEvent newAction)
    {
        Name = name;
        _action = newAction;
    }

    public PawnAction(string name, UnityAction newAction)
    {
        Name = name;
        _action = new();
        _action.AddListener(newAction);
    }

    [field: SerializeField] public string Name { get; private set; }
    [SerializeField] UnityEvent _action;

    public void Input()
    {
        _action.Invoke();
    }
}
[Serializable]
public struct PawnAxisAction
{
    public PawnAxisAction(string name, UnityEvent<Vector2> axisAction)
    {
        Name = name;
        _action = axisAction;
    }

    [field: SerializeField] public string Name { get; private set; }
    [SerializeField] UnityEvent<Vector2> _action;

    public void Input(Vector2 input)
    {
        _action.Invoke(input);
    }

}

public interface IPawn
{
    public List<PawnAction> InputActions { get; }
    public List<PawnAxisAction> AxisActions { get; }
}

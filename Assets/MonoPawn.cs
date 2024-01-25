using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

#region PawnActions
[Serializable]
public struct PawnAction
{
    public PawnAction(string name, UnityEvent<FInputSO> newAction)
    {
        Name = name;
        _action = newAction;
        G_Action = default;
    }

    public PawnAction(string name, UnityAction<FInputSO> newAction)
    {
        Name = name;
        _action = new();
        _action.AddListener(newAction);
        G_Action = default;
    }

    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public GenericAction G_Action { get; private set; }
    [SerializeField] UnityEvent<FInputSO> _action;

    public void Input(FInputSO x)
    {
        _action.Invoke(x);
    }
}
[Serializable]
public struct PawnAxisAction
{
    public PawnAxisAction(string name, UnityEvent<Vector2> axisAction)
    {
        Name = name;
        _action = axisAction;
        Axis = default;
    }

    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public GenericAxis Axis { get; private set; }

    [SerializeField] UnityEvent<Vector2> _action;

    public void Input(Vector2 input)
    {
        _action.Invoke(input);
    }

}
#endregion
public class MonoPawn : MonoBehaviour
{
    [Header("Pawn")]
    public UnityEvent<MainController> OnPosses = new();
    public UnityEvent OnUnPosses = new();

    [field: SerializeField] public MainController MyController { get; private set; } 

    public void Posses(MainController newController)
    {
        MyController = newController;
        OnPosses.Invoke(newController);
    }

    public void UnPosses()
    {
        if (MyController == null) return;
        MyController = null;
        OnUnPosses.Invoke();
    }
}

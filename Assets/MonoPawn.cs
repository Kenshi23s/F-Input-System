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
    [field: SerializeField] public GenericInput G_Action { get; private set; }
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
    public UnityEvent<Controller> OnPosses = new();
    public UnityEvent OnUnPosses = new();

    [field: SerializeField] public Controller MyController { get; private set; }
    [field: SerializeField] public List<PawnAction> InputActions { get; private set; }
    [field: SerializeField] public PawnAxisAction[] AxisActions { get; private set; }


    public void AxisInputs(GenericAxis k, Vector2 v)
    {
        var col = AxisActions.Where(x => x.Axis == k).ToArray();
        if (!col.Any()) return;

        foreach (var action in col)
            action.Input(v);


    }


    public void ActionInput(GenericInput k, FKeyInputSO input)
    {
        var col = InputActions.Where(x => x.G_Action == k).ToArray();
        if (!col.Any()) return;

        foreach (var action in col)
            action.Input(input);


    }

    public void Posses(Controller newController)
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

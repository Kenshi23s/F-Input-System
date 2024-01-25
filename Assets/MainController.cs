using AYellowpaper.SerializedCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class MainController : MonoBehaviour
{

    [field: SerializeField] public MonoPawn ControlingPawn { get; private set; }

    [SerializeField]
    InputConfig _buttonConfig;

    public GenericController _controller { get; private set; }
    InputAction movement, Aim;

    public event Action<Vector2> MovementRefresh = delegate { };
    public event Action<Vector2> AimRefresh = delegate { };
    //Dictionary<InputType, UnityEvent<InputAction.CallbackContext>> _interpretInput;

    [SerializeField] PlayerInput _Input;

    private void Awake()
    {
        _controller = new();

    }

    private void OnEnable()
    {
        _controller.Enable();

        movement = _controller.Controller.Axis1;
        movement.Enable();

        Aim = _controller.Controller.Axis2;
        Aim.Enable();
    }

    private void OnDisable()
    {
        _controller.Disable();

        movement = _controller.Controller.Axis1;
        movement.Disable();

        Aim = _controller.Controller.Axis2;
        Aim.Disable();
    }



    private void OnValidate()
    {
        //if (PawnGO == ControlingPawn as MonoBehaviour) return; 
        if (ControlingPawn == null)
        {
            ControlingPawn = null; /*CurrentActions.Clear();*/ return;
        }
    }


    private void Start()
    {
        if (ControlingPawn == null || ControlingPawn == default) return;

        SetNewPawn(ControlingPawn);

    }

    private void Update()
    {
        MovementRefresh.Invoke(movement.ReadValue<Vector2>());
        AimRefresh.Invoke(Aim.ReadValue<Vector2>());
    }


    public void SetNewPawn(MonoPawn pawn)
    {
        if (ControlingPawn != null)
        {
            ControlingPawn.UnPosses(this);
        }
        ControlingPawn = pawn;

        ControlingPawn.Posses(this);


    }

    #region Editor
#if UNITY_EDITOR
    [ContextMenu("Set As CurrentPawn")]

    void SelectCurrentPawn()
    {
        var x = Selection.gameObjects
            .Select(x => x.GetComponent<MonoPawn>())
            .Where(x => x != null)
            .First();

        if (x == null) return;

        SetNewPawn(x);
    }

#endif
    #endregion
}

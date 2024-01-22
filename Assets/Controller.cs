using AYellowpaper.SerializedCollections;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;


public class Controller : MonoBehaviour
{



    [field: SerializeField] public MonoPawn ControlingPawn { get; private set; }

    [SerializeField]
    InputConfig _buttonConfig;

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
        SendButtonInputs();
    }

    void SendButtonInputs()
    {
        foreach (GenericInput item in Enum.GetValues(typeof(GenericInput)))
        {
            if (!_buttonConfig.GetInput(item, out var x)) continue;

            ControlingPawn.ActionInput(item, x);

        }
    }


    void SetNewPawn(MonoPawn pawn)
    {

        //CurrentActions.Clear();
        pawn.Posses(this);
        //foreach (var item in )
        //{
        //    CurrentActions.Add(item, default);
        //}
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

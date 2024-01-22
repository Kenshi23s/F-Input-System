using AYellowpaper.SerializedCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Controller : MonoBehaviour
{


    public IPawn ControlingPawn { get; private set; }
    [SerializeField] private MonoBehaviour PawnGO;

    [SerializedDictionary, SerializeField]
    SerializedDictionary<PawnAction, FInputSO> CurrentActions = new();

    private void OnValidate()
    {
        //if (PawnGO == ControlingPawn as MonoBehaviour) return; 
        if (PawnGO as IPawn == null )
        {
            PawnGO = null; CurrentActions.Clear(); return;
        }
     





    }


    private void Start()
    {
        if (ControlingPawn == null || ControlingPawn == default) return;

        SetNewPawn(ControlingPawn);

    }
#if UNITY_EDITOR
    [ContextMenu("Set As CurrentPawn")]

    void SelectCurrentPawn()
    {
        var x = Selection.gameObjects
            .Select(x => x.GetComponent<IPawn>())
            .Where(x => x != null)
            .First();

        if (x == null) return;

        SetNewPawn(x);
    }

#endif
    void SetNewPawn(IPawn pawn)
    {

        CurrentActions.Clear();
        Debug.Log(pawn);
        foreach (var item in pawn.InputActions)
        {
            CurrentActions.Add(item, default);
        }
    }
}

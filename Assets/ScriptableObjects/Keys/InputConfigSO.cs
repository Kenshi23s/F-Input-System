using AYellowpaper.SerializedCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GenericAction
{

    Jump
   , Reload
   , Crouch
   , ChangeWeapon
   , Fire1
   , Fire2,
    Lethal
   , Tactical
}

public enum GenericAxis
{
    Axis1, Axis2, Axis3

}

[CreateAssetMenu(fileName = "KeyConfig", menuName = "ScriptableObjects/FInput/KeyConfig")]
public class InputConfig : ScriptableObject
{
    [SerializedDictionary, SerializeField]
    SerializedDictionary<GenericAction, FKeyInputSO> Inputs = new();

    [SerializedDictionary, SerializeField]
    SerializedDictionary<GenericAxis, F_AxisInputSO> Axis = new();


    public bool GetInput(GenericAction x, out FKeyInputSO input)
    {
        input = default(FKeyInputSO);
        if (!Inputs.TryGetValue(x, out var v)) return false;

        if (v == null || v == default) return false;

        input = v;
        return true;

    }


    public Vector2 GetAxis(GenericAxis x)
    {
        if (!Axis.TryGetValue(x, out var v)) return Vector2.zero;

        if (v == null || v == default) return Vector2.zero;

        return v.GetAxis();

    }
}

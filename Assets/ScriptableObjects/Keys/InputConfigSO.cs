using AYellowpaper.SerializedCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GenericInput
{
    Button1,
    Button2,
    Button3,
    Button4,
    Button5,
    Button6,
    Button7,
    Button8,
    Button9,
    Button10,
    Button11,
    Button12,
    Button13,
    Button14,
    Button15,
    Button16
}

public enum GenericAxis
{
    Axis1, Axis2, Axis3

}

[CreateAssetMenu(fileName = "KeyConfig", menuName = "ScriptableObjects/FInput/KeyConfig")]
public class InputConfig : ScriptableObject
{
    [SerializedDictionary, SerializeField]
    SerializedDictionary<GenericInput, FKeyInputSO> Inputs = new();

    [SerializedDictionary, SerializeField]
    SerializedDictionary<GenericAxis, F_AxisInputSO> Axis = new();


    public bool GetInput(GenericInput x,out FKeyInputSO input)
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

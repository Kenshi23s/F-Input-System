using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public struct Stick
{
    public Vector2 Axis;


    public Stick SetAxis(float x, float y)
    {
        this.Axis.y = y;
        this.Axis.x = x;
        return this;

    }
}


public interface IControl
{
    Stick LeftStick { get; }
    Stick RightStick { get; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AxisInput", menuName = "ScriptableObjects/FInput/Axis/Mouse")]
public class MouseAxisSO : F_AxisInputSO
{
    public override Vector2 GetAxis()
    {
        return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }
}

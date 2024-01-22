using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AxisInput", menuName = "ScriptableObjects/FInput/Axis/Keyboard")]
public class WASD_Axis : F_AxisInputSO
{
    //remplazar con un array de 4 teclas

    public override Vector2 GetAxis()
    {
        Vector2 dir = Vector2.zero;

        if (Input.GetKeyDown(KeyCode.W))
            dir += Vector2.up;

        if (Input.GetKeyDown(KeyCode.S))
            dir += Vector2.down;

        if (Input.GetKeyDown(KeyCode.D))
            dir += Vector2.right;

        if (Input.GetKeyDown(KeyCode.A))
            dir += Vector2.left;


        return dir.normalized;
    }
}

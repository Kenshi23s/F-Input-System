using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AxisInput", menuName = "ScriptableObjects/FInput/Axis/Keyboard")]
public class WASD_Axis : F_AxisInputSO
{
    //remplazar con un array de 4 teclas(por si el jugador quiere usar las teclas para moverse en vez de WASD)

    public override Vector2 GetAxis()
    {
        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            dir += Vector2.up;

        if (Input.GetKey(KeyCode.S))
            dir += Vector2.down;

        if (Input.GetKey(KeyCode.D))
            dir += Vector2.right;

        if (Input.GetKey(KeyCode.A))
            dir += Vector2.left;


        return dir;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dualshock : MonoBehaviour, IControl
{
    [field : SerializeField]
    public Stick LeftStick { get; private set; }

    [field: SerializeField] 
    public Stick RightStick { get; private set; }

    private void Update()
    {

        LeftStick = LeftStick.SetAxis(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Debug.Log(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 left = new Vector3(LeftStick.Axis.x, 0, LeftStick.Axis.y); 
        Gizmos.DrawLine(transform.position,(transform.position + left) * 10);
        Gizmos.DrawWireSphere(transform.position + left,  1);
    }

}

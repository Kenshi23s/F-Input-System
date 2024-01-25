using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Test : MonoPawn
{

    public Misile projectile;
    public Transform shootPos;




    void Shoot(InputAction.CallbackContext context)
    {
        Debug.Log(projectile);
        var x = Instantiate(projectile, transform.position, Quaternion.identity);
        x.InitializeProjectile(this);
        x.GetComponent<Rigidbody>().AddForce(transform.forward * 10);

    }



    public void Move(Vector2 inputdir)
    {
        if (inputdir == Vector2.zero) return;

        //Debug.LogError("Moviendome: " + inputdir);
        transform.position += new Vector3(inputdir.x, 0, inputdir.y) * 2 * Time.deltaTime;
        Debug.DrawLine(transform.position, transform.position + (GetOrientedVector(inputdir, transform).normalized * 3), Color.red);
        Debug.DrawLine(transform.position, transform.forward + transform.position, Color.blue);
    }


    public void Look(Vector2 newlookdir)
    {
        if (newlookdir == Vector2.zero) return;

        transform.forward = Vector3.right * newlookdir.x + Vector3.forward * newlookdir.y;



    }



    public Vector3 GetOrientedVector(Vector3 T, Transform tr)
    {
        return (T.x * tr.right + T.y * tr.up + tr.forward * T.z).normalized;
    }


    public override void SetInputs(MainController x)
    {
        Debug.Log("B");
        x.AimRefresh += Look;
        x.MovementRefresh += Move;
        x._controller.Controller.Fire1.performed += Shoot;
    }

    public override void RemoveInputs(MainController x)
    {
        Debug.Log("A");
        x.AimRefresh -= Look;
        x.MovementRefresh -= Move;
        x._controller.Controller.Fire1.performed -= Shoot;
    }
}

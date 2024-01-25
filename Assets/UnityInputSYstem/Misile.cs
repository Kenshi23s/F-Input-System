using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Misile : MonoPawn
{
    MonoPawn Owner;
    Rigidbody RB;


    Vector3 GetSteerValue;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    public void InitializeProjectile(MonoPawn shooter)
    {
        Owner = shooter;
        Owner.MyController.SetNewPawn(this);
    }



    void SetSteerValue(Vector2 value)
    {
        GetSteerValue = new Vector3(value.x, 0, value.y);
    }

    public Vector3 GetOrientedVector(Vector3 T, Transform tr)
    {
        return (T.x * tr.right + T.y * tr.up + tr.forward * T.z).normalized;
    }
    private void FixedUpdate()
    {
        RB.velocity += GetOrientedVector(GetSteerValue, transform) * 2;
        RB.velocity = Vector3.ClampMagnitude(RB.velocity, 4);
    }

    private void OnTriggerEnter(Collider other)
    {


        LeaveMisile(default);
        Destroy(gameObject);
    }

    void LeaveMisile(InputAction.CallbackContext _)
    {
        MyController.SetNewPawn(Owner);
    }

    public override void SetInputs(MainController newController)
    {
        newController.AimRefresh += SetSteerValue;
        var x = newController._controller.Controller;
        x.Fire1.performed += LeaveMisile;


    }

    public override void RemoveInputs(MainController oldController)
    {
        oldController.AimRefresh -= SetSteerValue;
        var x = oldController._controller.Controller;
        x.Fire1.performed -= LeaveMisile;
    }
}

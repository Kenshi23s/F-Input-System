using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test : MonoPawn
{



    private void Awake()
    {
        OnPosses.AddListener(SetInputs);
    }

    void SetInputs(MainController x)
    {
        x.AimRefresh += Look;
        x.MovementRefresh += Move;
    }

    public void Move(Vector2 inputdir)
    {
        if (inputdir == Vector2.zero) return;

        Debug.LogError("Moviendome: " + inputdir);
        transform.position += new Vector3(inputdir.x, 0, inputdir.y) * 2 * Time.deltaTime;
        Debug.DrawLine(transform.position, transform.position + (GetOrientedVector(inputdir, transform).normalized * 3), Color.red);
        Debug.DrawLine(transform.position, transform.forward + transform.position, Color.blue);
    }


    public void Look(Vector2 newlookdir)
    {
        if (newlookdir == Vector2.zero) return;

        transform.forward = Vector3.right * newlookdir.x + Vector3.forward * newlookdir.y;



    }


    //Vector3 ReorientInput(Vector3 v)
    //{
    //    v.Normalize();
    //    var x = new Vector3(transform.right.x * v.x, 0, transform.forward * v.);
    //    Debug.LogWarning(v);
    //    Debug.LogWarning(x);


    //    return x;
    //}
    public Vector3 GetOrientedVector(Vector3 T, Transform tr)
    {
        return (T.x * tr.right + T.y * tr.up + tr.forward * T.z).normalized;
    }
    public void ChangeToRed(FInputSO input)
    {
        if (input.InputHold(out var count))
        {
            if (count > 2f)
                GetComponent<Renderer>().material.color = Color.red;
        }


    }

    public void ChangeToBlue(FInputSO input)
    {
        if (input.InputHold(out var count))
        {
            if (count > 2f)
                GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}

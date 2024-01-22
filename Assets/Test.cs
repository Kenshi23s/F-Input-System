using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test : MonoPawn
{

    private void Awake()
    {
        //InputActions.Add(new PawnAction("ChangeToRed", ChangeToRed));
        //InputActions.Add(new PawnAction("ChangeToBlue", ChangeToBlue));
    }

    public void Move(Vector2 newlookdir)
    {
        transform.position += (Vector3.right * newlookdir.x + Vector3.forward * newlookdir.y) * Time.deltaTime * 2;
    }


    public void Look(Vector2 newlookdir)
    {
        transform.forward = transform.position + new Vector3(newlookdir.x, transform.position.y, newlookdir.y);
    }

    public void ChangeToRed()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void ChangeToBlue()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }
}

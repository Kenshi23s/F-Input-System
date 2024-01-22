using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour,IPawn
{
  
    [field: SerializeField] public List<PawnAction> InputActions { get; private set; }
    [field: SerializeField] public List<PawnAxisAction> AxisActions { get; private set; }


    private void Awake()
    {
        InputActions.Add(new PawnAction("ChangeToRed", ChangeToRed));
        InputActions.Add(new PawnAction("ChangeToBlue", ChangeToBlue));
    }

    void ChangeToRed()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
    void ChangeToBlue()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }
}

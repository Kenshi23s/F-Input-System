using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "KeyButtonInput", menuName = "ScriptableObjects/FInput/Button/Keyboard")]
public class FKeyInputSO : FInputSO
{
    [SerializeField] KeyCode[] keys;
    float _holdCount;
   

    public override bool InputHold(out float timeHolded)
    {
        timeHolded = 0f;
        if (keys.Length <= 0) return false;
     
        foreach (var key in keys)
        {
            if (!Input.GetKey(key)) { _holdCount = 0f; return false; }
        }
        _holdCount += Time.deltaTime;
        timeHolded = _holdCount;
        return true;
    }

    public override bool InputPress()
    {
        if (keys.Length <= 0) return false;
        foreach (var key in keys)
        {
            if (!Input.GetKeyDown(key)) return false;
        }
        return true;
    }

    public override bool InputRelease()
    {
        if (keys.Length <= 0) return false;
        foreach (var key in keys)
        {
            if (Input.GetKeyUp(key)) return true;
        }
        return false;
    }
}

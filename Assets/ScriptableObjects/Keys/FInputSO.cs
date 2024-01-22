using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FInputSO : ScriptableObject
{
    public abstract bool InputPress();
    public abstract bool InputHold(out float timeHolded);
    public abstract bool InputRelease();
}

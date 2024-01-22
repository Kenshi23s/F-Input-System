using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//deberia obtener todos los inputs del juego de la carpeta resources
public class InputChecker : MonoBehaviour
{
   public List<FInputSO> inputCheckerList;

    private void Update()
    {
        if (inputCheckerList.Any())
        {
            foreach (var inputChecker in inputCheckerList) { inputChecker.InputHold(out _); }
        }
    }
}

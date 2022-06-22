using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauzeButtons : MonoBehaviour
{
    [SerializeField] PauzeScript pauzeScript;

    public void OnClickResume()
    {
        pauzeScript.OnPauze(true);
    }
}

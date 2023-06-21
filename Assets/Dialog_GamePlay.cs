using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog_GamePlay 
{
    public string Name;
    [TextArea(5, 15)]
    public string[] sentences;
}

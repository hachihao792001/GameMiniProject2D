using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dialog
{
    None,
    JustInTime,
    Teach,
    DropFirstArea,
    Move,
    Approach,
    TrainingOver,
    Ready
}

[CreateAssetMenu(fileName = "DialogInfo", menuName = "ScriptableObjects/DialogInfo")]
public class DialogInfo : ScriptableObject
{
    public Dialog dialog;
    [TextArea(20, 5)]
    public string dialogContent;
}

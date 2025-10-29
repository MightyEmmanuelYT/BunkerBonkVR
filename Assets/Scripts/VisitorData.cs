using UnityEngine;

[System.Serializable]
public class VisitorData
{
    [Header("Visitor Info")]
    public string visitorName;
    [TextArea(2, 4)] public string dialogueLine;
    [TextArea(1, 3)] public string hintLine;

    [Header("Visitor Type")]
    public bool isMonster;
}

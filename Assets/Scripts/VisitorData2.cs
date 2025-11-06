using UnityEngine;

[System.Serializable]
public class VisitorData2
{
    public string visitorName;
    [TextArea] public string[] humanComments;
    [TextArea] public string[] monsterComments;
    public bool isMonster;
}

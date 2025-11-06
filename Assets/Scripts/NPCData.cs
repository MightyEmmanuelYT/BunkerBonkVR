using UnityEngine;

[System.Serializable]
public class NPCData
{
    public string visitorName;   // e.g. "Sarah", "Unknown Traveler"
    [TextArea(2, 5)]
    public string dialogueLine;  // what they say at the door
    public bool isMonster;       // true = monster, false = human
}

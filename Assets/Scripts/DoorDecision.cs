using UnityEngine;

public class DoorDecision : MonoBehaviour
{
    [Header("References")]
    public VisitorManager visitorManager;
    public Animator doorAnimator;

    [Header("Settings")]
    public float nextVisitorDelay = 3f;

    public void LetIn()
    {
        var npc = visitorManager.GetCurrentVisitor();
        if (npc == null) return;

        var data = npc.GetData();

        if (data.isMonster)
        {
            Debug.Log("You let in a MONSTER! Game Over.");
            // TODO: Trigger jump scare or attack animation here
        }
        else
        {
            Debug.Log("You helped a human. +1 Good Karma.");
            // TODO: Play happy or neutral reaction here
        }

        StartCoroutine(NextVisitor());
    }

    public void Deny()
    {
        var npc = visitorManager.GetCurrentVisitor();
        if (npc == null) return;

        var data = npc.GetData();

        if (data.isMonster)
        {
            Debug.Log("You denied a monster. You’re safe… for now.");
            // TODO: Maybe play angry growl and fade away
        }
        else
        {
            Debug.Log("You turned away a human...");
            // TODO: Sad reaction
        }

        StartCoroutine(NextVisitor());
    }

    private System.Collections.IEnumerator NextVisitor()
    {
        yield return new WaitForSeconds(nextVisitorDelay);
        visitorManager.SpawnVisitor();
    }
}

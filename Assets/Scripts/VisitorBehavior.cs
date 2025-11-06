using UnityEngine;

public class VisitorBehavior : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float triggerDistance = 2f;

    private VisitorData2 data;
    private Transform doorPoint;
    private bool hasTriggered = false;

    public void Setup(VisitorData2 visitorData2, Transform targetPoint)
    {
        data = visitorData2;
        doorPoint = targetPoint;
    }

    void Update()
    {
        if (doorPoint == null) return;

        // Move toward door until close enough
        if (!hasTriggered)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorPoint.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, doorPoint.position) < triggerDistance)
            {
                hasTriggered = true;
                DialogueManager2.Instance.ShowDialogue($"{data.visitorName}: \"{GetRandomIntro()}\"");
            }
        }
    }

    string GetRandomIntro()
    {
        if (data.isMonster)
        {
            string[] lines = { "Please... it’s cold out here...", "I’m just... so hungry...", "Let me in... I won’t hurt you..." };
            return lines[Random.Range(0, lines.Length)];
        }
        else
        {
            string[] lines = { "Please, let me in!", "I’m just looking for shelter!", "There’s something out there!" };
            return lines[Random.Range(0, lines.Length)];
        }
    }

    public void ReactToDecision(bool letIn)
    {
        string[] lines;
        if (data.isMonster)
        {
            lines = letIn
                ? new[] { "Heh... big mistake.", "Finally... dinner.", "You shouldn’t have done that." }
                : new[] { "You can’t keep me out forever...", "We’ll meet again...", "Fine... but I’ll remember this." };
        }
        else
        {
            lines = letIn
                ? new[] { "Thank you! I owe you my life.", "Bless you, kind soul.", "You’re saving lives in there." }
                : new[] { "Please... no!", "Why would you do this?!", "I thought you were human..." };
        }

        DialogueManager2.Instance.ShowDialogue($"{data.visitorName}: \"{lines[Random.Range(0, lines.Length)]}\"");
    }
}

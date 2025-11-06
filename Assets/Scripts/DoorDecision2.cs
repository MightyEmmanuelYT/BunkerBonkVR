using UnityEngine;
using System.Collections;

public class DoorDecision2 : MonoBehaviour
{
    public void LetIn()
    {
        HandleDecision(true);
    }

    public void Deny()
    {
        HandleDecision(false);
    }

    private void HandleDecision(bool letIn)
    {
        if (VisitorManager2.Instance == null) return;

        GameObject visitor = GameObject.FindObjectOfType<VisitorBehavior>()?.gameObject;
        if (visitor == null) return;

        VisitorBehavior vb = visitor.GetComponent<VisitorBehavior>();
        vb.ReactToDecision(letIn);

        // Remove visitor after a short delay
        VisitorManager2.Instance.StartCoroutine(RemoveAndRespawn());
    }

    private IEnumerator RemoveAndRespawn()
    {
        yield return new WaitForSeconds(2.5f);
        DialogueManager2.Instance.HideDialogue();
        VisitorManager2.Instance.RemoveVisitor();
        yield return new WaitForSeconds(1f);
        VisitorManager2.Instance.SpawnVisitor();
    }
}

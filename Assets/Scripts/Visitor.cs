using UnityEngine;

public class Visitor : MonoBehaviour
{
    public string dialogueLine = "Please... let me in!";
    public float triggerDistance = 2f;
    public Transform playerCamera; // leave this empty if you can’t drag
    private bool hasTriggered = false;

    void Start()
    {
        // Try to auto-find if nothing assigned
        if (playerCamera == null && Camera.main != null)
            playerCamera = Camera.main.transform;
    }

    void Update()
    {
        if (hasTriggered || playerCamera == null) return;

        if (Vector3.Distance(transform.position, playerCamera.position) < triggerDistance)
        {
            hasTriggered = true;
            DialogueManager2.Instance.ShowDialogue(dialogueLine);
        }
    }
}

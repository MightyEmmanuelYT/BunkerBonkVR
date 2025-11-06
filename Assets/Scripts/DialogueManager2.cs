using UnityEngine;
using TMPro;

public class DialogueManager2 : MonoBehaviour
{
    public static DialogueManager2 Instance;

    [Header("References")]
    public TextMeshProUGUI dialogueText;
    public Canvas dialogueCanvas;

    private void Awake()
    {
        Instance = this;
        dialogueCanvas.enabled = false; // hidden by default
    }

    public void ShowDialogue(string text)
    {
        dialogueCanvas.enabled = true;
        dialogueText.text = text;
    }

    public void HideDialogue()
    {
        dialogueCanvas.enabled = false;
    }
}

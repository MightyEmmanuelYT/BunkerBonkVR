using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [Header("UI References")]
    public TextMeshProUGUI dialogueText;
    public CanvasGroup dialogueCanvas;

    private void Awake()
    {
        Instance = this;

        if (dialogueCanvas)
            dialogueCanvas.alpha = 1; // Always visible
    }

    public void ShowDialogue(string message)
    {
        Debug.Log("DialogueManager received: " + message);

        if (dialogueCanvas) dialogueCanvas.alpha = 1;
        if (dialogueText)
        {
            dialogueText.text = message;
            dialogueText.color = Color.white; // force visible color
        }
    }


    //public void ShowDialogue(string message)
    //{
    //    if (dialogueCanvas) dialogueCanvas.alpha = 1;
    //    if (dialogueText) dialogueText.text = message;
    //}

    public void ClearDialogue()
    {
        if (dialogueText) dialogueText.text = "";
    }
}

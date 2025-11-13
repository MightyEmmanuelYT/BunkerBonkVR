using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RadialMenuManager : MonoBehaviour
{
    public Button talkButton;
    public Button testButton;
    public Button giveButton;
    public Button leaveButton;

    private ResidentBehavior currentResident;

    public void Initialize(ResidentBehavior resident)
    {
        currentResident = resident;
        transform.LookAt(Camera.main.transform); // Face player

        talkButton.onClick.AddListener(() => OnOptionSelected("Talk"));
        testButton.onClick.AddListener(() => OnOptionSelected("Test"));
        giveButton.onClick.AddListener(() => OnOptionSelected("Give"));
        leaveButton.onClick.AddListener(() => OnOptionSelected("Leave"));
    }

    private void OnOptionSelected(string option)
    {
        switch (option)
        {
            case "Talk":
                currentResident.TriggerDialogue();
                break;
            case "Test":
                currentResident.TriggerTest();
                break;
            case "Give":
                currentResident.TriggerGive();
                break;
            case "Leave":
                HideMenu();
                return;
        }

        HideMenu();
    }

    public void HideMenu()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;

public class ResidentBehavior : MonoBehaviour
{
    [Header("Resident Info")]
    public string residentName;
    [TextArea] public string[] idleDialogue;
    [TextArea] public string[] repeatDialogue;

    [Header("Interaction Settings")]
    public float interactionDistance = 2.5f;
    public Transform playerCamera;

    private bool menuOpen = false;
    private GameObject activeMenu;

    private void Start()
    {
        if (playerCamera == null && Camera.main != null)
            playerCamera = Camera.main.transform;
    }

    private void Update()
    {
        if (playerCamera == null) return;

        float distance = Vector3.Distance(playerCamera.position, transform.position);

        if (distance < interactionDistance && !menuOpen)
        {
            ShowRadialMenu();
            Debug.Log($"{residentName}: Player entered interaction range!");
        }
        else if (distance > interactionDistance && menuOpen)
        {
            CloseRadialMenu();
        }
    }

    private void ShowRadialMenu()
    {
        GameObject menuPrefab = Resources.Load<GameObject>("UI/RadialMenu");
        if (menuPrefab == null)
        {
            Debug.LogWarning("RadialMenu prefab not found in Resources/UI");
            return;
        }

        Debug.Log("Attempting to load and show RadialMenu prefab...");

        activeMenu = Instantiate(menuPrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
        RadialMenuManager menu = activeMenu.GetComponent<RadialMenuManager>();
        menu.Initialize(this);
        menuOpen = true;
    }

    private void CloseRadialMenu()
    {
        if (activeMenu != null)
            Destroy(activeMenu);

        menuOpen = false;
    }

    // --- Called by RadialMenuManager ---
    public void TriggerDialogue()
    {
        string line = idleDialogue.Length > 0 ? idleDialogue[Random.Range(0, idleDialogue.Length)] : "They remain silent.";
        DialogueManager2.Instance.ShowDialogue($"{residentName}: \"{line}\"");
    }

    public void TriggerTest()
    {
        DialogueManager2.Instance.ShowDialogue($"{residentName}: \"I don't know much about that...\"");
    }

    public void TriggerGive()
    {
        DialogueManager2.Instance.ShowDialogue($"{residentName}: \"Thanks... I guess.\"");
    }
}

using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject Light;

    [SerializeField] private Vector3 OpenPos;
    [SerializeField] private Vector3 ClosePos;

    public bool IsOpen;

    [SerializeField] private float DoorSpeed = 2f;

    [SerializeField] private PowerSystem Power;

    private bool doorSystemOn; // Tracks door power usage

    void Start()
    {
        transform.position = OpenPos; // Door starts open
        IsOpen = true;
        doorSystemOn = false;         // Open door = no power

        // Keep lights as before
        ChangeLights();
    }

    void Update()
    {
        // Smoothly move the door toward the target position
        Vector3 targetPos = IsOpen ? OpenPos : ClosePos;

        if (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, DoorSpeed * Time.deltaTime);
        }
    }

    // Call this to toggle the door from VR input
    public void ToggleDoor()
    {
        IsOpen = !IsOpen;

        // Door closed = power ON
        SetDoorPower(!IsOpen);
    }

    private void SetDoorPower(bool state)
    {
        if (doorSystemOn == state) return;

        doorSystemOn = state;

        if (state)
            Power.SystemsOn += 1;
        else
            Power.SystemsOn -= 1;
    }

    // Lights remain independent
    public void ChangeLights()
    {
        bool IsOn = !Light.activeSelf;
        Light.SetActive(IsOn);

        if (IsOn)
            Power.SystemsOn += 1;
        else
            Power.SystemsOn -= 1;
    }
}

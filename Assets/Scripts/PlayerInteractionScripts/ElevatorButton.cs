using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ElevatorButton : MonoBehaviour
{
    public ElevatorController elevator;
    public int floorNumber; // 0, -1, or -2

    void Start()
    {
        GetComponent<XRSimpleInteractable>()
            .selectEntered.AddListener(x => PressButton());
    }

    private void PressButton()
    {
        elevator.GoToFloor(floorNumber);
    }
}

using UnityEngine;

public class PeepHoleCameraController : MonoBehaviour
{
    public Camera peepHoleCamera;
    public GameObject peepHoleCover;

    private bool isPeeking = false;

    void Start()
    {
        if (peepHoleCamera) peepHoleCamera.enabled = false;
    }

    public void TogglePeepHole()
    {
        isPeeking = !isPeeking;

        if (peepHoleCamera)
            peepHoleCamera.enabled = isPeeking;

        if (peepHoleCover)
            peepHoleCover.SetActive(!isPeeking);

        Debug.Log(isPeeking ? "Looking through peep hole..." : "Closed peep hole.");
    }
}

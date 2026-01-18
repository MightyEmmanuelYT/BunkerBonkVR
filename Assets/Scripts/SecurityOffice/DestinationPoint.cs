using UnityEngine;

public class DestinationPoint : MonoBehaviour
{
    [SerializeField] private DestinationPoint[] points;

    public bool IsDoor;
    public bool IsOffice;

    public Door Door;
}

using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    void Update()
    {
        if (Camera.main != null)
            transform.LookAt(Camera.main.transform);
    }
}

using UnityEngine;

public class VRButtonTeleport : MonoBehaviour
{
    [Header("Teleport Targets")]
    public Transform teleportTarget1;
    public Transform teleportTarget2;
    public Transform teleportTarget3;

    [Header("Player")]
    public Transform playerRig; // Usually the parent of the VR camera

    // Call this function from your button's OnClick() event
    public void TeleportToTarget1()
    {
        TeleportPlayer(teleportTarget1);
    }

    public void TeleportToTarget2()
    {
        TeleportPlayer(teleportTarget2);
    }

    public void TeleportToTarget3()
    {
        TeleportPlayer(teleportTarget3);
    }

    private void TeleportPlayer(Transform target)
    {
        if (playerRig == null || target == null) return;

        // Move the player's rig to the target position
        playerRig.position = target.position;
        playerRig.rotation = target.rotation; // Optional: matches rotation
    }
}

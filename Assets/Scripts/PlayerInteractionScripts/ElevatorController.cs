using UnityEngine;
using System.Collections;

public class ElevatorController : MonoBehaviour
{
    public Transform groundFloor;
    public Transform floorMinus1;
    public Transform floorMinus2;

    public float moveSpeed = 2f;

    private Coroutine moveRoutine;

    public void GoToFloor(int floor)
    {
        Transform target = null;

        switch (floor)
        {
            case 0:
                target = groundFloor;
                break;
            case -1:
                target = floorMinus1;
                break;
            case -2:
                target = floorMinus2;
                break;
        }

        if (target == null) return;

        if (moveRoutine != null)
            StopCoroutine(moveRoutine);

        moveRoutine = StartCoroutine(MoveElevator(target.position));
    }

    private IEnumerator MoveElevator(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );

            yield return null;
        }
    }
}

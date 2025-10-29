using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCBehavior : MonoBehaviour
{
    private VisitorData data;
    private NavMeshAgent agent;
    private Transform doorPosition;

    [Header("Audio")]
    public AudioSource knockSound;
    public AudioSource voiceLine;

    private bool hasKnocked = false;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Setup(VisitorData visitorData, Transform door)
    {
        data = visitorData;
        doorPosition = door;
        ApproachDoor();
    }

    void ApproachDoor()
    {
        agent.SetDestination(doorPosition.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DoorTrigger") && !hasKnocked)
        {
            hasKnocked = true;
            StartCoroutine(DialogueSequence());
        }
    }

    IEnumerator DialogueSequence()
    {
        // Knock first
        if (knockSound) knockSound.Play();
        yield return new WaitForSeconds(2f);

        // Dialogue
        Debug.Log($"{data.visitorName}: {data.dialogueLine}");
        if (voiceLine) voiceLine.Play();

        // Optional: show subtitles or enable peep hole UI
    }

    public VisitorData GetData()
    {
        return data;
    }
}

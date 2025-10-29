using UnityEngine;

public class VisitorManager : MonoBehaviour
{
    [Header("Prefabs & Spawn Settings")]
    public GameObject humanPrefab;
    public GameObject monsterPrefab;
    public Transform spawnPoint;
    public Transform doorPosition;

    [Header("Visitor Profiles")]
    public VisitorData[] visitorProfiles;

    private GameObject currentVisitor;

    public void Start()
    {
        SpawnVisitor();
    }

    public void SpawnVisitor()
    {
        // Remove old visitor if one exists
        if (currentVisitor != null)
        {
            Destroy(currentVisitor);
        }

        // Pick random visitor profile
        VisitorData data = visitorProfiles[Random.Range(0, visitorProfiles.Length)];
        GameObject prefab = data.isMonster ? monsterPrefab : humanPrefab;

        // Spawn and set up
        currentVisitor = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        currentVisitor.GetComponent<NPCBehavior>().Setup(data, doorPosition);
    }

    public NPCBehavior GetCurrentVisitor()
    {
        if (currentVisitor == null) return null;
        return currentVisitor.GetComponent<NPCBehavior>();
    }
}

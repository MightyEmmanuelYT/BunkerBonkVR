using UnityEngine;
using System.Collections;

public class VisitorManager2 : MonoBehaviour
{
    public static VisitorManager2 Instance;

    [Header("Spawn Setup")]
    public Transform spawnPoint;
    public Transform doorPoint;
    public GameObject visitorPrefab;

    [Header("Visitors Data")]
    public VisitorData2[] possibleVisitors;

    private GameObject currentVisitor;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnVisitor();
    }

    public void SpawnVisitor()
    {
        if (currentVisitor != null)
            Destroy(currentVisitor);

        VisitorData2 randomData = possibleVisitors[Random.Range(0, possibleVisitors.Length)];

        currentVisitor = Instantiate(visitorPrefab, spawnPoint.position, spawnPoint.rotation);
        VisitorBehavior visitorScript = currentVisitor.GetComponent<VisitorBehavior>();
        visitorScript.Setup(randomData, doorPoint);
    }

    public void RemoveVisitor()
    {
        if (currentVisitor != null)
        {
            Destroy(currentVisitor);
            currentVisitor = null;
        }
    }
}

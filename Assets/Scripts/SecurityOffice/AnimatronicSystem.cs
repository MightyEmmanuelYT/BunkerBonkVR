using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class AnimatronicSystem : MonoBehaviour
{
    [SerializeField] private NavMeshAgent NMA;
    [SerializeField] private GameObject[] Targets;

    [SerializeField] private int CurrentTarget;

    [SerializeField] private float CoolDownTimer;
    [SerializeField] private float MinCoolDownTime;
    [SerializeField] private float MaxCoolDownTime;

    [SerializeField] private int MinChanceToMove = 1;
    [SerializeField] private int MaxChanceToMove = 20;

    [SerializeField] private int ThresholdToPass = 3;

    [SerializeField] private int[] AggressionByHour;

    [SerializeField] private int MinAggressionToAdd = 2;
    [SerializeField] private int MaxAggressionToAdd = 5;

    [SerializeField] private int HoursChanged;

    [SerializeField] private PlayableDirector Director;
    [SerializeField] private bool StartedJumpscare;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NMA = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Count down the cooldown timer first
        CoolDownTimer -= Time.deltaTime;

        if (CoolDownTimer <= 0f)
        {
            var chanceCheck = Random.Range(MinChanceToMove, MaxChanceToMove);

            if (chanceCheck <= ThresholdToPass)
            {
                if (Vector3.Distance(transform.position, Targets[CurrentTarget].transform.position) <= 0.5f)
                {
                    var dest = Targets[CurrentTarget].GetComponent<DestinationPoint>();

                    if (dest.IsDoor)
                    {
                        if (dest.Door.IsOpen)
                        {
                            CurrentTarget = Targets.Length - 1;
                        }
                        else
                        {
                            CurrentTarget = 1;
                        }
                    }
                    else if (dest.IsOffice)
                    {
                        Debug.Log("You Died");
                    }
                    else
                    {
                        CurrentTarget += 1;
                        if (CurrentTarget >= Targets.Length)
                            CurrentTarget = 0;
                    }
                }
            }

            // Reset the timer after moving
            var CoolDownTime = Random.Range(MinCoolDownTime, MaxCoolDownTime);
            CoolDownTimer = CoolDownTime;
        }

        if (Targets[CurrentTarget].GetComponent<DestinationPoint>().IsOffice)
        {
            if (!StartedJumpscare)
            {
                Director.Play();
                StartedJumpscare = true;
            }
        }
        // Always update NavMeshAgent destination
        NMA.destination = Targets[CurrentTarget].transform.position;
    }

    public void ChangeAggressionByHour(int hour)
    {
        if(HoursChanged != hour)
        {
            if (ThresholdToPass < hour)
            {
                ThresholdToPass = AggressionByHour[hour];  //This is the manual way to do it
            }

            ThresholdToPass += Random.Range(MinAggressionToAdd, MaxAggressionToAdd);  //This is the randomised way to do it
            HoursChanged += 1;
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

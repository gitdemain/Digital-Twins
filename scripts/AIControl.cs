using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AIControl : MonoBehaviour {

    public TMP_Dropdown Safety_zones;
    public Button crowd_sim;
    public Button flood_sim;

    GameObject[] goals;
    int buttonCrowdSimOn = 0;
    int buttonFloodSimOn = 0;
//    GameObject[] people;
    GameObject[] rescue_zones;
    NavMeshAgent agent;
    float detectionRadius = 80;
//    float fleeRadius = 10;
//    public GameObject water_cube_1;

    //    Animator anim;
    private void Start() 
    {

        agent = GetComponent<NavMeshAgent>();
//        crowd_sim.onClick.AddListener(crowdSimulator);
//        flood_sim.onClick.AddListener(floodSimulator);
        goals = GameObject.FindGameObjectsWithTag("goal");
        rescue_zones = GameObject.FindGameObjectsWithTag("Safe_zone");

        /*
                people = GameObject.FindGameObjectsWithTag("active_crowd");
                Safety_zones = FindAnyObjectByType<TMP_Dropdown>();
                water_cube_1 = GameObject.FindGameObjectWithTag("");
        */

        //        Safety_zones.onValueChanged.AddListener(OnSafeZoneListChange);

        //        anim = this.GetComponent<Animator>();
        //        anim.SetTrigger("isWalking");
        //        ResetAgent();
    }

    private void crowdSimulator()
    {
//        int i = Random.Range(0, goals.Length);
//        agent.SetDestination(goals[i].transform.position);
        buttonCrowdSimOn = 1;
        buttonFloodSimOn = 0;
    }
    private void floodSimulator()
    {
        buttonCrowdSimOn = 0;
        buttonFloodSimOn = 1;
    }
    /*    void detectFlood(Vector3 pos)
        {
            if(Vector3.Distance(pos, this.transform.position) < detectionRadius)
                {
                    Vector3 fleeDir = (this.transform.position - pos).normalized;
                    Vector3 newgoal = this.transform.position + fleeDir * fleeRadius;

                    NavMeshPath path = new NavMeshPath();
                    agent.CalculatePath(newgoal, path);
                    if(path.status == NavMeshPathStatus.PathComplete)
                    {
                        agent.SetDestination(path.corners[path.corners.Length-1]);
                        agent.speed = 15;
                        agent.angularSpeed = 500;
                    }
                    else 
                    {
                        foreach (GameObject g in goals)
                            {
                                if (path.status == NavMeshPathStatus.PathComplete)
                                {
                                    agent.SetDestination(g.transform.position);
                                }

                            }
                    }

                }
        }
    */
    /*    private void OnSafeZoneListChange(int index)
        {

            if (Safety_zones.value == 1)
            {
                agent.SetDestination(rescue_zones[0].transform.position);
            }
            if (Safety_zones.value == 2)
            {
                agent.SetDestination(rescue_zones[1].transform.position);
            }
            if (Safety_zones.value == 3)
            {
                agent.SetDestination(rescue_zones[2].transform.position);
            }
        }
    */


    /*
        void ResetAgent()
        {
            agent.speed = 7;
            agent.ResetPath();
            agent.angularSpeed = 120;
        }
    */
    void Update() 
    {

        crowd_sim.onClick.AddListener(crowdSimulator);
        flood_sim.onClick.AddListener(floodSimulator);
        if(buttonCrowdSimOn == 1)
        {
            if (agent.remainingDistance < 3)
            {
                int j = Random.Range(0, goals.Length);
                agent.SetDestination(goals[j].transform.position);
            }
        }
        if(buttonFloodSimOn == 1)
        {
            if (Safety_zones.value == 1)
            {
                agent.SetDestination(rescue_zones[0].transform.position);
            }
            if (Safety_zones.value == 2)
            {
                agent.SetDestination(rescue_zones[1].transform.position);
            }
            if (Safety_zones.value == 3)
            {
                agent.SetDestination(rescue_zones[2].transform.position);
            }
        }


        /*        foreach(GameObject a in people) 
                      {
                          detectFlood(water_cube_1.transform.position);
                      }
        */
    }

}
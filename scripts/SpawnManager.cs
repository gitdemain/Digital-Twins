using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.AI.Navigation;
using System;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
//    public Transform ControllerTransform;
//    public InputActionProperty selectAction;
//    private Transform hitpointTransform;
    public Transform spawnTransform;
    public GameObject spawnPrefab;
    private float spawnRadius = 5.0f;
    public TMP_Dropdown People_Number;
    private List<GameObject> spawned_people = new List<GameObject>();
    private NavMeshSurface navMeshSurface;
    private int numberOfPeople = 0;
//    GameObject[] people;

    // Start is called before the first frame update
    private void Start()
    {
        navMeshSurface = FindAnyObjectByType <NavMeshSurface>();
    }

    private void spawnPeople()
    {
//        Vector3 randomSpawnPos = randomNavMeshPos(hitpointTransform.position, spawnRadius);
        Vector3 randomSpawnPos = randomNavMeshPos(spawnTransform.position, spawnRadius);

        if (randomSpawnPos != Vector3.zero)
        {
            GameObject newObject = Instantiate(spawnPrefab,randomSpawnPos,Quaternion.identity);
            spawned_people.Add( newObject );
            
            NavMeshAgent agent = newObject.GetComponent<NavMeshAgent>();
            if( agent != null )
            {
                agent.speed = 20;
            }
        }
    }

    private Vector3 randomNavMeshPos(Vector3 pos, float radius)
    {
        NavMeshHit hit;
        Vector3 rand_pos = pos + UnityEngine.Random.insideUnitSphere * radius;
        if(NavMesh.SamplePosition(rand_pos,out hit, radius,NavMesh.AllAreas))
        {
            return hit.position;
        }
        return Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        //        people = GameObject.FindGameObjectsWithTag("active_crowd");
/*
        if (selectAction.action.WasPressedThisFrame())
        {
            Ray ray = new Ray(ControllerTransform.position,ControllerTransform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 hitpoint = hit.point;
                Quaternion hitRotation = Quaternion.LookRotation(hit.normal);
                hitpointTransform.SetPositionAndRotation(hitpoint, hitRotation);
            }
        }
*/
        //        numberOfPeople = Int32.Parse(People_Number.text);

        if (People_Number.value == 1)
        {
            numberOfPeople = 20;
        }
        if (People_Number.value == 2)
        {
            numberOfPeople = 30;
        }
        if (People_Number.value == 3)
        {
            numberOfPeople = 40;
        }
        if (People_Number.value == 4)
        {
            numberOfPeople = 50;
        }
        if (People_Number.value == 5)
        {
            numberOfPeople = 60;
        }
        if (People_Number.value == 6)
        {
            numberOfPeople = 70;
        }
        if (People_Number.value == 7)
        {
            numberOfPeople = 80;
        }
        if (People_Number.value == 8)
        {
            numberOfPeople = 90;
        }
        if (People_Number.value == 9)
        {
            numberOfPeople = 100;
        }
        if (spawned_people.Count < numberOfPeople)
        {
            spawnPeople();
        }
    }

}

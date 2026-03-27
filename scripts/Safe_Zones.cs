using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class Safe_Zones : MonoBehaviour
{
    [SerializeField]
    public TMP_Dropdown Safety_zones;

    GameObject[] rescue_zones;
    GameObject[] ppl;
    NavMeshAgent agent_1;

    void Start()
    {
        agent_1 = GetComponent<NavMeshAgent>();
//        ppl = GameObject.FindGameObjectsWithTag("crowd");
    }

    private void Update()
    {
        Safety_zones.onValueChanged.AddListener(OnSafeZoneListChange);
    }
    private void OnSafeZoneListChange(int index)
    {

        if (Safety_zones.value == 1)
        {
            rescue_zones[0] = GameObject.FindGameObjectWithTag("Safe_Zone_1");
            agent_1.SetDestination(rescue_zones[0].transform.position);
        }
        if (Safety_zones.value == 2)
        {
            rescue_zones[1] = GameObject.FindGameObjectWithTag("Safe_Zone_2");
            agent_1.SetDestination(rescue_zones[1].transform.position);
        }
        if (Safety_zones.value == 3)
        {
            rescue_zones[2] = GameObject.FindGameObjectWithTag("Safe_Zone_3");
            agent_1.SetDestination(rescue_zones[2].transform.position);
        }
    }
}

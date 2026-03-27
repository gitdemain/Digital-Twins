using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Camera_attachment : MonoBehaviour
{
//    private GameObject attached_object;
    public TMP_Dropdown People;
//    public GameObject Sec_cam;

    private GameObject[] ppl;
//    int pplCounter = 0; // to notify update function which spawned person to follow
    int x; // to be used as index from 1 to the length-1 of number of spawned people
    private Vector3 offset = new Vector3 (0, 5.5f, 0-8.42f);

    void Start()
    {
    }
/*
    private void OnPeopleListChange(int index)
    {
        if (People.value == 1)
        {
            pplCounter = 1;
        }
        if (People.value == 2)
        {
            pplCounter = 2;
        }
        if (People.value == 3)
        {
            pplCounter = 3;
        }
    }
*/
    void Update()
    {
//       People.onValueChanged.AddListener(OnPeopleListChange);

        ppl = GameObject.FindGameObjectsWithTag("active_crowd");
        x = ppl.Length/2;

        if (People.value == 1)
        {
            transform.position = ppl[x].transform.position + offset;
        }
        if (People.value == 2)
        {
            transform.position = ppl[x - 1].transform.position + offset;
        }
        if (People.value == 3)
        {
            transform.position = ppl[x + 1].transform.position + offset;
        }
    }
}

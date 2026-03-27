using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class People_list : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown People;

    [SerializeField]
    GameObject Sec_cam;

    private GameObject[] ppl;

    private void Start()
    {
        People.onValueChanged.AddListener(OnPeopleListChange);
        ppl = GameObject.FindGameObjectsWithTag("active_crowd");
    }

    private void OnPeopleListChange(int index)
    {
        int x = Random.Range(0, ppl.Length-1);
        if (People.value == 1)
        {
            GameObject switch_cam = Instantiate(Sec_cam, this.transform.position, Quaternion.identity);
//            switch_cam.GetComponent<Camera_attachment>().attached_object = ppl[index];
        }
        if (People.value == 2)
        {
            GameObject switch_cam = Instantiate(Sec_cam, this.transform.position, Quaternion.identity);
//            switch_cam.GetComponent<Camera_attachment>().attached_object = ppl[index-1];
        }
        if (People.value == 3)
        {
            GameObject switch_cam = Instantiate(Sec_cam, this.transform.position, Quaternion.identity);
//            switch_cam.GetComponent<Camera_attachment>().attached_object = ppl[index+1];
        }
    }

}

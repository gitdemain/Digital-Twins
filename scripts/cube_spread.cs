using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class cube_spread : MonoBehaviour
{
    public GameObject water_pre;
    private Vector3 spawn_pos;
    public Button flood_sim_on;
    private int f = 0;
    // Start is called before the first frame update
    private void Start()
            {
//                spawn_pos = water_pre.transform.position;
                spawn_pos = new Vector3(320,116,118);
                flood_sim_on.onClick.AddListener(flooding);
            }

    // Update is called once per frame
    void flooding()
    {
        f = 1;
    }
    void Update()
    {
        //        flood_sim_on.onClick.AddListener(flood_spread);
        if (f == 1)
        {
            Ray ray = Camera.main.ScreenPointToRay(spawn_pos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 spawn_position = hit.point + Vector3.up * 0.01f;
                Instantiate(water_pre, spawn_position, Quaternion.identity);
            }
        }
    }
/*
    void flood_spread()
    {
        Ray ray = Camera.main.ScreenPointToRay(spawn_pos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 spawn_position = hit.point + Vector3.up * 0.01f;
            Instantiate(water_pre, spawn_position, Quaternion.identity);
        }

    }
*/

    /*
        void start_spread()
        {
            Vector3 spawn_Pos = transform.position;
            GameObject cube = Instantiate(water_pre,spawn_Pos,Quaternion.identity);
            foreach (Vector3 dir in spread_dir)
            {
                InvokeRepeating(nameof(spread_Water),spread_Interval,spread_Interval);
            }
        }

        void spread_Water()
        {
                foreach (Vector3 dir in spread_dir)
                {
                    RaycastHit hit;
                    if (!Physics.Raycast(transform.position, dir, out hit, spread_Distance,LayerMask.GetMask("Default"), QueryTriggerInteraction.Collide))
                    {
                        Vector3 new_pos = transform.position + (dir * spread_Distance);
                        GameObject new_Water_Cube = Instantiate(water_pre, new_pos, Quaternion.identity);
                        transform.position = new_pos;
                    }
                }

            cube_spread cube_Spread_Component = new_Water_Cube.GetComponent<cube_spread>();
            if (cube_Spread_Component != null )
            {
                cube_Spread_Component = new_Water_Cube.AddComponent<cube_spread>();
            }
    */
}
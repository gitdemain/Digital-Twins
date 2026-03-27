using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class water_spread : MonoBehaviour
{

    public float spread_Interval = 2f;
    public float spread_Distance = 5;
//    public Button flood_sim;
//    public Button crowd_sim;
//    private int buttonFloodSimOn;
//    private int buttonCrowdSimOn;
    public GameObject water;
    private float timer;
//    public Button flood_sim_on;
//    private int f = 0;
    private Vector3[] spread_dir = {
        Vector3.forward,
        Vector3.back,
        Vector3.left,
        Vector3.right,
    };

    private void Start()
    {
//        crowd_sim.onClick.AddListener(crowdSimOn);
        timer = spread_Interval;
//        flood_sim_on.onClick.AddListener(flooding);

    }

/*
    private void flooding()
    {
        f = 1;
    }
*/

    void Update()
    {

//        flood_sim.onClick.AddListener(floodSimOn);
         timer -= Time.deltaTime;
        if (timer <= 0)
        {
            foreach (Vector3 direction in spread_dir)
            {
                SpreadWater(direction);
            }
            timer = spread_Interval;
        }
    }
/*
    private void floodSimOn()
    {
        //        buttonFloodSimOn = 1;
        //        buttonCrowdSimOn = 0;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            foreach (Vector3 direction in spread_dir)
            {
                SpreadWater(direction);
            }
            timer = spread_Interval;
        }

    }
*/
    /*
        private void crowdSimOn()
        {
            buttonCrowdSimOn = 1;
            buttonFloodSimOn = 0;
        }
    */
    private void SpreadWater(Vector3 dir)
    {
        RaycastHit hit;
        if(!Physics.Raycast(transform.position, dir, out hit, spread_Distance))
        {
            Vector3 newPos = transform.position + (dir * spread_Distance);
            GameObject newWaterInstance = Instantiate(water, newPos, Quaternion.identity);

            water_spread waterSpreadComponent = newWaterInstance.GetComponent<water_spread>();
            if(waterSpreadComponent == null )
            {
                waterSpreadComponent = newWaterInstance.AddComponent<water_spread>();
            }
        }
    }

}

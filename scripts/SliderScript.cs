using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private float max = 100;
    [SerializeField] private TextMeshProUGUI slider_text;

    public void SliderChange(float value)
    {
//        float localVal= value;
        slider_text.text = value.ToString("0");
    }

}

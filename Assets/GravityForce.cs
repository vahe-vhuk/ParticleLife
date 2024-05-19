using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GravityForce : MonoBehaviour
{
    [SerializeField] private Slider slid;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI mode;
    
    void Start()
    {
        slid.onValueChanged.AddListener((v) =>
        {
            text.text = v.ToString("0.00");

            if (v < 0)
            {
                mode.text = "Eject";
            }
            else
            {
                mode.text = "Gravitate";
            }

            Config.conf[slid.tag] = v;
        });
    }

    void Update()
    {
        
    }
}

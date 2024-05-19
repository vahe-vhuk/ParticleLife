using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButtn : MonoBehaviour
{
    public GameObject settingPanel;


    public void handleClick()
    {
        if (settingPanel.activeInHierarchy)
        {
            settingPanel.SetActive(false);
        }
        else
        {
            settingPanel.SetActive(true);
        }
        
    }
    
    void Start()
    {
        settingPanel.SetActive(false);
    }

    void Update()
    {
        
    }
}

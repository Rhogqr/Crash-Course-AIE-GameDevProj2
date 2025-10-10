using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightSwitchTask : MonoBehaviour
{
    [SerializeField] Toggle[] lightSwitches;
    [SerializeField] GameObject[] sceneLights;
    bool lightOff = false;
    bool runLightTask = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LightOffChecker();
        LightSwitchRandomiser();
        SwitchesOnChecker();
    }

    private void SwitchesOnChecker()
    {
        int tempLightChecker = 0;
        for (int i = 0; i < lightSwitches.Length; i++)
        {

            if (lightSwitches[i].isOn)
            {
                tempLightChecker++;
            }
        }
        if (tempLightChecker == 8)
        {
            for (int i = 0; i < sceneLights.Length; i++)
            {
                sceneLights[i].SetActive(true);
            }
            for (int i = 0; i < lightSwitches.Length; i++)
            {
                lightSwitches[i].isOn = false;
            }
            lightOff = false;
        }
    }

    public void TurnRandomLightOff()
    {
        for (int i = 0; i < sceneLights.Length; i++)
        {
            sceneLights[Random.Range(0, i+1)].SetActive(false);
        }
    }

    private void LightSwitchRandomiser()
    {
        if (runLightTask)
        {
            runLightTask = false;
            do
                for (int i = 0; i < 4; i++)
                {
                    int randIndex;
                    randIndex = Random.Range(0, 8);
                    lightSwitches[randIndex].isOn = true;
                }
            while (!areFourSwitchesActive());
        }
    }

    private void LightOffChecker()
    {
        for (int i = 0; i < sceneLights.Length && !lightOff; i++)
        {
            if (!sceneLights[i].activeInHierarchy)
            {
                lightOff = true;
                runLightTask = true;
            }
        }
    }

    bool areFourSwitchesActive()
    {
        int switchesOn = 0;
        for (int i = 0; i < lightSwitches.Length; i++)
        {
            if (lightSwitches[i].isOn)
            {
                switchesOn++;
            }
        }
        if (switchesOn == 4)
        {
            return true;
        }
        else
        {
            for (int i = 0; i < lightSwitches.Length; i++)
            {
                lightSwitches[i].isOn = false;
            }
            return false;
            
        }     
    }
}

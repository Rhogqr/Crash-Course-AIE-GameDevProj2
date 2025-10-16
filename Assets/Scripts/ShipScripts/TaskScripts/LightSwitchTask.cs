using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightSwitchTask : MonoBehaviour
{
    [SerializeField] Toggle[] lightSwitches;
    [SerializeField] GameObject[] sceneLights;
    public bool lightOff = false;
    bool runLightTask = false;
    [SerializeField] int lightOffChance;
    // Start is called before the first frame update
    void Start()
    {
        // starts the function that randomly turns off lights
        StartCoroutine(LightTurnOff());
    }

    // Update is called once per frame
    void Update()
    {
        // checks if lights are off
        LightOffChecker();
        // creates a random puzzle for the player to click through
        LightSwitchRandomiser();
        //checks if the player has finished the puzzle
        SwitchesOnChecker();
    }

    private void SwitchesOnChecker()
    {
        // goes through each index of the light breaker toggles to see if they are all on
        int tempLightChecker = 0;
        for (int i = 0; i < lightSwitches.Length; i++)
        {

            if (lightSwitches[i].isOn)
            {
                tempLightChecker++;
            }
        }
        // if all toggles are on, then turn on every light, and turn off all the toggles to 'reset'
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

    IEnumerator LightTurnOff()
    {
        // every 10 seconds, 1/[lightOffChance] chance to turn a random light in the scene off
        while (true)
        {
            yield return new WaitForSeconds(10f);
            int rand = Random.Range(0, lightOffChance);
            if (rand == 0)
            {
                TurnRandomLightOff();
            }
        }
    }
    public void TurnRandomLightOff()
    {
        // goes through a GameObject array and chooses a random light to turn off
        sceneLights[Random.Range(0, sceneLights.Length)].SetActive(false);
    }

    private void LightSwitchRandomiser()
    {
        // if >=1 lights are off, then choose 4 random toggles to turn on, then make the player turn on the other 4
        if (runLightTask)
        {
            // keeps running random puzzle generator until no repeats are hit during the setup process
            runLightTask = false;
            do
                for (int i = 0; i < 4; i++)
                {
                    // chooses a random toggle in the array, then sets it to true
                    int randIndex;
                    randIndex = Random.Range(0, 8);
                    lightSwitches[randIndex].isOn = true;
                }
            while (!areFourSwitchesActive());
        }
    }

    private void LightOffChecker()
    {
        // continually checks to see if any of the lights in the scene are off
        for (int i = 0; i < sceneLights.Length && !lightOff; i++)
        {
            if (!sceneLights[i].activeInHierarchy)
            {
                // if >= light(s) are off, then start the light task
                lightOff = true;
                runLightTask = true;
            }
        }
    }

    bool areFourSwitchesActive()
    {
        // checks how many toggles are on in the array of them
        int switchesOn = 0;
        for (int i = 0; i < lightSwitches.Length; i++)
        {
            if (lightSwitches[i].isOn)
            {
                switchesOn++;
            }
        }
        // if 4 are on (if no slots were done twice during setup), then return true, else, return false
        if (switchesOn == 4)
        {
            return true;
        }
        else
        {
            // reset the puzzle if repeats are found
            for (int i = 0; i < lightSwitches.Length; i++)
            {
                lightSwitches[i].isOn = false;
            }
            return false;
            
        }     
    }
}

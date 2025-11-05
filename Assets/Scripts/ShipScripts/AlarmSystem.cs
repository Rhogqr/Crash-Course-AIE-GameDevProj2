using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] GameObject[] alarmLights;
    PumpScript pS;
    HealthBar hB;
    SineWaveAlt sWA;
    TaskDebuffAlien tDA;

    bool tempF;
    bool tempL;
    bool tempR;
    void Start()
    {
        pS = GameObject.Find("OxygenPumpSlider").GetComponent<PumpScript>();
        hB = GameObject.Find("HealthBar").GetComponent <HealthBar>();
        sWA = GameObject.Find("SineWaveAlt").GetComponent<SineWaveAlt>();
        tDA = GameObject.Find("Task Guy Prototypes").GetComponent<TaskDebuffAlien>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // if oxygen low, start front alarm
        if (pS.meterPrcnt < 25 && tempF)
        {
            StartCoroutine("frontLightFlash");
            tempF = false;
        }
        else
        {
            StopCoroutine("frontLightFlash");
            alarmLights[0].SetActive(false);
            tempF = true;
        }
        // if health low, start left alarm
        if ((hB.currentHealth < 25 || tDA.debuff2) && tempL)
        {
            StartCoroutine("leftLightFlash");
            tempL = false;
        }
        else if (hB.currentHealth > 25 && !tDA.debuff2)
        {
            StopCoroutine("leftLightFlash");
            alarmLights[1].SetActive(false);
            tempL = true;
        }

        // if sine wave are out of sync, start right alarm
        if ((sWA.commsFailure || tDA.debuff1) && tempR)
        {
            StartCoroutine("rightLightFlash");
            tempR = false;
        }
        else if (!sWA.commsFailure && !tDA.debuff1)
        {
            StopCoroutine("rightLightFlash");
            alarmLights[2].SetActive(false);
            tempR = true;
        }
    }

    IEnumerator frontLightFlash()
    {
        // alternates the light on and off every second
        while (true)
        {
            Debug.Log("Flashing Front Light");
            yield return new WaitForSeconds(1);
            alarmLights[0].SetActive(true);
            yield return new WaitForSeconds(1);
            alarmLights[0].SetActive(false);
        }
    }
    IEnumerator leftLightFlash()
    {
        // alternates the light on and off every second
        while (true)
        {
            yield return new WaitForSeconds(1);
            alarmLights[1].SetActive(true);
            yield return new WaitForSeconds(1);
            alarmLights[1].SetActive(false);
        }
    }
    IEnumerator rightLightFlash()
    {
        // alternates the light on and off every second
        while (true)
        {
            yield return new WaitForSeconds(1);
            alarmLights[2].SetActive(true);
            yield return new WaitForSeconds(1);
            alarmLights[2].SetActive(false);
        }
    }
}

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
        //pS = GameObject.Find("OxygenPump").GetComponent<PumpScript>();
        hB = GameObject.Find("HealthBar").GetComponent <HealthBar>();
        sWA = GameObject.Find("SineWaveAlt").GetComponent<SineWaveAlt>();
        tDA = GameObject.Find("Task Guy Prototypes").GetComponent<TaskDebuffAlien>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (pS.meterPrcnt < 25 && tempF)
        //{
        //    StartCoroutine("frontLightFlash");
        //    tempF = false;
        //}
        //else
        //{
        //    StopCoroutine("frontLightFlash");
        //    alarmLights[0].SetActive(false);
        //    tempL = true;
        //}

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
        while (true)
        {
            yield return new WaitForSeconds(.5f);
            alarmLights[0].SetActive(true);
            yield return new WaitForSeconds(.2f);
            alarmLights[0].SetActive(false);
        }
    }
    IEnumerator leftLightFlash()
    {
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
        while (true)
        {
            yield return new WaitForSeconds(1);
            alarmLights[2].SetActive(true);
            yield return new WaitForSeconds(1);
            alarmLights[2].SetActive(false);
        }
    }
}

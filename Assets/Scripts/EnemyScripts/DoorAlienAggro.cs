using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAlienAggro : MonoBehaviour
{
    MainDoorTest mDT;
    LightSwitchTask lST;
    TaskDebuffAlien tDA;
    SineWaveAlt sWA;

    [SerializeField] GameObject analogHorror;
    public int prevProgressCheck;
    public bool isSpinningTooFast;
    [SerializeField] bool noIssuesOnShip;

    // Start is called before the first frame update
    void Start()
    {
        mDT = GameObject.Find("Vault_Door").GetComponent<MainDoorTest>();
        lST = GameObject.Find("LightTaskHolder").GetComponent <LightSwitchTask>();
        tDA = GameObject.Find("Task Guy Prototypes").GetComponent<TaskDebuffAlien>();
        sWA = GameObject.Find("SineWaveAlt").GetComponent<SineWaveAlt>();

        prevProgressCheck = mDT.progressCheck;
        StartCoroutine(SpinCheckerDelay());

        isSpinningTooFast = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpinningTooFast)
        {
            analogHorror.SetActive(true);
        }
        else
        {
            analogHorror.SetActive(false); 
        }
        Debug.Log("1" + tDA.debuff1);
        Debug.Log("2" + tDA.debuff2);
        Debug.Log("3" + lST.lightOff);
        Debug.Log("4" + sWA.commsFailure);
        if (tDA.debuff1 || tDA.debuff2 || lST.lightOff || sWA.commsFailure)
        {
            Debug.Log("Issues");
            noIssuesOnShip = false;
        }
        else
        {
            Debug.Log("No Issues");
            noIssuesOnShip = true;
        }
    }

    IEnumerator SpinCheckerDelay()
    {
        while (true)
        {
            SpinChecker();
            yield return new WaitForSeconds(1f);
        }
    }
    void SpinChecker()
    {
        if (prevProgressCheck - mDT.progressCheck >= 3)
        {
            if (!noIssuesOnShip)
            {
                Debug.Log("Spinning Too Fast");
                isSpinningTooFast = true;
            }

            prevProgressCheck = mDT.progressCheck;
        }
        else
        {
            isSpinningTooFast = false;
        }
    }
}

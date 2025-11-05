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
        // initalises scripts in other objects to use their variables
        mDT = GameObject.Find("Vault_Door").GetComponent<MainDoorTest>();
        lST = GameObject.Find("LightTaskHolder").GetComponent <LightSwitchTask>();
        tDA = GameObject.Find("Task Guy Prototypes").GetComponent<TaskDebuffAlien>();
        sWA = GameObject.Find("SineWaveAlt").GetComponent<SineWaveAlt>();

        // initialises the spins/second counter
        prevProgressCheck = mDT.progressCheck;

        // checks how many spins are done every second
        StartCoroutine(SpinCheckerDelay());

        // initialises isSpinningTooFast so that the player doesnt get an instant jumpscare
        isSpinningTooFast = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if the player is deemed to be spinning too fast, then activate jumpscare
        if (isSpinningTooFast)
        {
            analogHorror.SetActive(true);
        }
        else
        {
            analogHorror.SetActive(false); 
        }

        // checks if there are any issues on ships, if so sets the bool that caps spins at 3/s to false
        if (tDA.debuff1 || tDA.debuff2 || lST.lightOff || sWA.commsFailure)
        {
            noIssuesOnShip = false;
        }
        else
        {
            noIssuesOnShip = true;
        }
    }

    IEnumerator SpinCheckerDelay()
    {
        while (true)
        {
            // repeats the SpinChecker function once a second
            SpinChecker();
            yield return new WaitForSeconds(1f);
        }
    }
    void SpinChecker()
    {
        // checks if the player is spinning equal to or more than 3 times / second
        if (prevProgressCheck - mDT.progressCheck >= 3)
        {
            // if there are no issues on the ship, dont spawn door alien
            if (!noIssuesOnShip)
            {
                // if there are issues on the ship the player should deal with, then let the door alien spawn
                isSpinningTooFast = true;
            }
        }
        else
        {
            // returns that the player is not spinning too fast
            isSpinningTooFast = false;
        }
        // set every second to check teh difference between last and current second
        prevProgressCheck = mDT.progressCheck;
    }
}

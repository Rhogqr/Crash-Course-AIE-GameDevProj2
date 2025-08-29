using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingSky : MonoBehaviour
{
    public PlayerStatsManager pSM;
    public MainDoorTest mDT;
    public float timeOfSkyRise;
    float maxCountdownTime;
    // Start is called before the first frame update
    void Start()
    {
        pSM = GameObject.Find("PlayerStatsManager").GetComponent<PlayerStatsManager>();
        mDT = GameObject.Find("Door").GetComponent<MainDoorTest>();
        
        maxCountdownTime = pSM.timerTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeOfSkyRise = maxCountdownTime * Time.deltaTime;
        if (mDT.progressCheck > 0 && !pSM.isGameOver)
        {
            transform.Translate(0, 1/timeOfSkyRise, 0);
        }
    }
}

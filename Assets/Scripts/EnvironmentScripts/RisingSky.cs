using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RisingSky : MonoBehaviour
{
    public PlayerStatsManager pSM;
    public MainDoorTest mDT;
    public float timeOfSkyRise;
    float maxCountdownTime;
    public GameObject SkyEffects;
    // Start is called before the first frame update
    void Start()
    {
        pSM = GameObject.Find("PlayerStatsManager").GetComponent<PlayerStatsManager>();
        mDT = GameObject.Find("Vault_Door").GetComponent<MainDoorTest>();
        
        maxCountdownTime = pSM.timerTime;
    }

    // Update is called once per frame
    void Update()
    {
        // moves the skybox up over the duration of the countdown timer
        timeOfSkyRise = maxCountdownTime * Time.deltaTime;
        if (mDT.progressCheck > 0 && !pSM.isGameOver)
        {
            transform.Translate(0, 1/timeOfSkyRise, 0);
        }
        SkyEffects.transform.Translate(0, 2, 0);
        if (SkyEffects.transform.position.y >= 26)
        {
            SkyEffects.transform.Translate(0, -46.5f, 0);
        }
    }
}

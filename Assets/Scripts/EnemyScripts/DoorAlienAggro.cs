using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAlienAggro : MonoBehaviour
{
    public MainDoorTest mDT;
    public PlayerStatsManager pSM;
    public GameObject analogHorror;
    public int prevProgressCheck;
    bool isSpinningTooFast;

    // Start is called before the first frame update
    void Start()
    {
        pSM = GameObject.Find("PlayerStatsManager").GetComponent<PlayerStatsManager>();
        mDT = GameObject.Find("Vault_Door").GetComponent<MainDoorTest>();
        prevProgressCheck = mDT.progressCheck;
        StartCoroutine(SpinCheckerDelay());
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
        if (prevProgressCheck- mDT.progressCheck >= 3)
        {
            isSpinningTooFast = true;
        }
        else
        {
            isSpinningTooFast = false;
        }
        prevProgressCheck = mDT.progressCheck;
    }
}

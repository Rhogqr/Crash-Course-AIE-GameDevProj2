using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeStunAlien : MonoBehaviour
{
    PlayerStatsManager pSM;

    public GameObject[] eyeGuys;

    [SerializeField] string directionChecker;
    bool isSummoned;
    public bool isStunned;

    [SerializeField] int eyeChance = 10;

    [SerializeField] GameObject LightningEffect;

    // Start is called before the first frame update
    void Start()
    {
        pSM = GameObject.Find("PlayerStatsManager").GetComponent<PlayerStatsManager>();
        directionChecker = pSM.playerDirection;
    }

    // Update is called once per frame
    void Update()
    {
        EyeSpawn();

        if (isSummoned)
        {
            StartCoroutine(VariableDelay());
        }

    }
    IEnumerator VariableDelay()
    {
        yield return new WaitForSeconds(2);

        int isPlayerMoved = 0;
        for (int i = 0; i < eyeGuys.Length; i++)
        {
            if (eyeGuys[i].activeInHierarchy)
            {
                isPlayerMoved = i+1;
                
            }
        }

        if (isPlayerMoved > 0)
        {
            isStunned = true;

            LightningEffect.SetActive(true);
            yield return new WaitForSeconds(5);
            Debug.Log(isStunned);
            eyeGuys[isPlayerMoved-1].SetActive(false);
            LightningEffect.SetActive(false);
            isSummoned = false;
            isStunned = false;
        }
        else
        {
            isSummoned = false;
            isStunned = false;
        }
        isPlayerMoved = 0;
    }
    private void EyeSpawn()
    {
        if (directionChecker != pSM.playerDirection)
        {
            for (int i = 0; i < eyeGuys.Length; i++)
            {
                eyeGuys[i].SetActive(false);
            }

            int doEyeSpawn;
            doEyeSpawn = Random.Range(0, eyeChance);
            if (doEyeSpawn == 0)
            {
                if (pSM.playerDirection == "Forward")
                {
                    eyeGuys[0].SetActive(true);
                }
                else if (pSM.playerDirection == "Right")
                {
                    eyeGuys[1].SetActive(true);
                }
                else if (pSM.playerDirection == "Left")
                {
                    eyeGuys[2].SetActive(true);
                }
                isSummoned = true;
            }
            else
            {
                isSummoned = false;
            }

            directionChecker = pSM.playerDirection;
        }
       
    }

}

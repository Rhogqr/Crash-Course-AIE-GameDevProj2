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
        // runs a small chance to spawn the eye alien if the player has changed direction
        EyeSpawn();

        // if an eye is summoned, wait a few seconds to see if the player moves or stays on the screen
        if (isSummoned)
        {
            StartCoroutine(VariableDelay());
        }

    }
    IEnumerator VariableDelay()
    {
        // waits 2 seconds to see if the player has moved
        yield return new WaitForSeconds(2);

        // gets which eye is active
        int isPlayerMoved = 0;
        for (int i = 0; i < eyeGuys.Length; i++)
        {
            if (eyeGuys[i].activeInHierarchy)
            {
                isPlayerMoved = i+1;
                
            }
        }

        // if the player hasnt moved, stun them with a lightning effect
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
        // if the player has moved, dont stun
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
            // if the player has looked away from eye alien, then turn it off
            for (int i = 0; i < eyeGuys.Length; i++)
            {
                eyeGuys[i].SetActive(false);
            }

            // random chance to spawn eye alien
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

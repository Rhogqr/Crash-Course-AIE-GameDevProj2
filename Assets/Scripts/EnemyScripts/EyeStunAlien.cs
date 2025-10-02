using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeStunAlien : MonoBehaviour
{
    PlayerStatsManager pSM;
    public GameObject[] eyeGuys;
    [SerializeField] string directionChecker;


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
            doEyeSpawn = Random.Range(0, 10);
            if (doEyeSpawn == 9)
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
            }
            directionChecker = pSM.playerDirection;
        }
    }
}

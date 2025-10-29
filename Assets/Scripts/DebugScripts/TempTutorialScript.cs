using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempTutorialScript : MonoBehaviour
{
    PlayerStatsManager pSM;
    [SerializeField] GameObject[] tutorialScreens;
    string tempDirection = "";
    // Start is called before the first frame update
    void Start()
    {
        pSM = GameObject.Find("PlayerStatsManager").GetComponent<PlayerStatsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("PrototypeStartScreen");
        }


        if (tempDirection != pSM.playerDirection)
        {
            switch (tempDirection)
            {
                case "Forward":
                    tutorialScreens[0].SetActive(false);
                    break;
                case "Left":
                    tutorialScreens[1].SetActive(false);
                    break;
                case "Right":
                    tutorialScreens[2].SetActive(false);
                    break;
                case "Backward":
                    tutorialScreens[3].SetActive(false);
                    break;

            }
        }
        tempDirection = pSM.playerDirection;

    }

}

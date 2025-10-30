using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempTutorialScript : MonoBehaviour
{
    [SerializeField] string playerDirection;
    [SerializeField] GameObject[] tutorialScreens;
    string tempDirection = "";
    public GameObject mainPlayerCam;

    [SerializeField] GameObject HealthBar;
    [SerializeField] GameObject SineWave;
    [SerializeField] GameObject SineWaveAlt;
    //[SerializeField] GameObject OxygenPump;
    [SerializeField] GameObject EyeAlien;
    [SerializeField] GameObject TaskAlien;

    // Start is called before the first frame update
    void Start()
    {
        mainPlayerCam = GameObject.Find("Main Camera");
        HealthBar.SetActive(false);
        SineWave.SetActive(false);
        SineWaveAlt.SetActive(false);
        //OxygenPump.SetActive(false);
        EyeAlien.SetActive(false);
        TaskAlien.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("PrototypeStartScreen");
        }

        transform.rotation = mainPlayerCam.transform.rotation;

        //if (tempDirection != playerDirection)
        //{
        //    switch (tempDirection)
        //    {
        //        case "Forward":
        //            tutorialScreens[0].SetActive(false);
        //            break;
        //        case "Left":
        //            tutorialScreens[1].SetActive(false);
        //            break;
        //        case "Right":
        //            tutorialScreens[2].SetActive(false);
        //            break;
        //        case "Backward":
        //            tutorialScreens[3].SetActive(false);
        //            break;

        //    }
        //}
        //tempDirection = playerDirection;

        if (playerDirection == "Forward")
        {
            tutorialScreens[0].SetActive(true);
            //if (OxygenPump != null)
            //OxygenPump.SetActive(true);
        }
        else
        {
            tutorialScreens[0].SetActive(false);
            //OxygenPump.SetActive(false);
        }
        if (playerDirection == "Left")
        {
            tutorialScreens[1].SetActive(true);
            HealthBar.SetActive(true);
            EyeAlien.SetActive(true);
        }
        else
        {
            tutorialScreens[1].SetActive(false);
            HealthBar.SetActive(false);
            EyeAlien.SetActive(false);
        }
        if (playerDirection == "Right")
        {
            tutorialScreens[2].SetActive(true);
            SineWave.SetActive(true);
            SineWaveAlt.SetActive(true);
            TaskAlien.SetActive(true);
        }
        else
        {
            tutorialScreens[2].SetActive(false);
            SineWave.SetActive(false);
            SineWaveAlt.SetActive(false);
            TaskAlien.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Direction"))
        {
            playerDirection = other.name;
        }
    }

}

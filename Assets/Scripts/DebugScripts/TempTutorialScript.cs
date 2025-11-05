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
    [SerializeField] GameObject OxygenPump;
    [SerializeField] GameObject EyeAlien;
    [SerializeField] GameObject TaskAlien;

    // Start is called before the first frame update
    void Start()
    {
        mainPlayerCam = GameObject.Find("Main Camera");
        // turns off functionality for most objects in the scene
        HealthBar.SetActive(false);
        SineWave.SetActive(false);
        SineWaveAlt.SetActive(false);
        OxygenPump.SetActive(false);
        EyeAlien.SetActive(false);
        TaskAlien.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            // if escape is pressed, load the main menu scene
            SceneManager.LoadScene("PrototypeStartScreen");
        }

        // since the player stats manager is not active in this scene, we use this temp method to track player direction
        transform.rotation = mainPlayerCam.transform.rotation;

        // shows and hides tutorial screens based on player direction
        if (playerDirection == "Forward")
        {
            tutorialScreens[0].SetActive(true);
            OxygenPump.SetActive(true);
        }
        else
        {
            tutorialScreens[0].SetActive(false);
            OxygenPump.SetActive(false);
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
        // gets the player direction
        if (other.CompareTag("Direction"))
        {
            playerDirection = other.name;
        }
    }

}

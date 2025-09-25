using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

// as of now, most of this script does nothing. its currently linked to the door so dont delete this please!
// i (reuben) plan to use this as storage for variables that revolve around the player (current rotation, time left, player health, etc.)

public class PlayerStatsManager : MonoBehaviour
{
    public GameObject mainPlayerCam;

    public MainDoorTest mDT;
    public EngineBar engineBar;
    public HealthBar healthBar;

    public string playerDirection;

    public TextMeshProUGUI timerText;
    public GameObject LoseText;
    public float timerTime;
    public bool isGameOver = false;

    public AudioClip onInteractAudioEventClip;
    AudioSource audioSource;

    // this is a placeholder number but will likely be final, things will have to change to re set this
    public int targetFPS = 60;
    

    // Start is called before the first frame update
    void Start()
    {
        mainPlayerCam = GameObject.Find("Main Camera");

        mDT = GameObject.Find("Vault_Door").GetComponent<MainDoorTest>();
        engineBar = GameObject.Find("EngineCanvas").GetComponentInChildren<EngineBar>();
        healthBar = GameObject.Find("HealthCanvas").GetComponentInChildren<HealthBar>();

        timerText = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            GetRotationAsString();
            CountdownLossManager();
            PlaySoundOnInteract();

           if (engineBar.currentEngine <= 0 || healthBar.currentHealth <= 0)
           {
                LoseText.SetActive(true);
                isGameOver = true;
           }
           transform.rotation = mainPlayerCam.transform.rotation;
        }
    }

    private void PlaySoundOnInteract()
    {
        if (Input.GetKeyDown(KeyCode.E) && (playerDirection == "Left" || playerDirection == "Right"))
        {
            audioSource.clip = onInteractAudioEventClip;
            audioSource.Play();
        }
    }

    private void CountdownLossManager()
    {
        if (timerTime >= 1 && !isGameOver && mDT.progressCheck > 0)
        {
            timerTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timerTime / 60);
            int seconds = Mathf.FloorToInt(timerTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else if (timerTime <= 1)
        {
            LoseText.SetActive(true);
            isGameOver = true;
        }
    }

    private void GetRotationAsString()
    {
        //// because of the way that the camera animation works, the timing on this update is inconsistent. fix later?
        //float currentDirection = mainPlayerCam.transform.rotation.eulerAngles.y;
        //if (currentDirection == 0)
        //{
        //    // Forward
        //    playerDirection = "Forward";
        //}
        //else if (currentDirection == 270)
        //{
        //    // Left
        //    playerDirection = "Left";
        //}
        //else if (currentDirection == 90)
        //{
        //    // Right
        //    playerDirection = "Right";
        //}
        //else if (currentDirection == 180)
        //{
        //    // Backward
        //    playerDirection = "Backward";
        //}
        //else
        //{
        //    // how
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Direction"))
        {
            playerDirection = other.name;
        }
    }

    private void Awake()
    {
        Application.targetFrameRate = targetFPS;
    }
}

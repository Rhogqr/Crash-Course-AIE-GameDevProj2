using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
//using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class PlayerStatsManager : MonoBehaviour
{
    public GameObject mainPlayerCam;

    public MainDoorTest mDT;
    public HealthBar healthBar;

    public string playerDirection;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timerText1;
    public TextMeshProUGUI timerText2;
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
        healthBar = GameObject.Find("HealthCanvas").GetComponentInChildren<HealthBar>();
        audioSource = GetComponent<AudioSource>();

        // fps = 60
        Application.targetFrameRate = targetFPS;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            // freeze time
            Time.timeScale = 0f;
            // unlock cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        // if the game is not over, 
        if (!isGameOver)
        {
            // manage the countdown timer
            CountdownLossManager();
            // if the player interacts with something, play the interaction sound
            PlaySoundOnInteract();
            // if health = 0, then game over
            if (healthBar.currentHealth <= 0)
            {
                LoseText.SetActive(true);
                isGameOver = true;
            }
            transform.rotation = mainPlayerCam.transform.rotation;
        }
    }

    private void PlaySoundOnInteract()
    {
        // if player interacts, then play sound
        if (Input.GetKeyDown(KeyCode.E) && (playerDirection == "Left"))
        {
            audioSource.clip = onInteractAudioEventClip;
            audioSource.Play();
        }
    }

    private void CountdownLossManager()
    {
        // manages the countdown timer and triggers game over when it hits 0
        if (timerTime >= 1 && !isGameOver && mDT.progressCheck > 0)
        {
            timerTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timerTime / 60);
            int seconds = Mathf.FloorToInt(timerTime % 60);
            // cant make an array of TMP so have to do this the long way
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            timerText1.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            timerText2.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else if (timerTime <= 1)
        {
            LoseText.SetActive(true);
            isGameOver = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // gets the direciton the player is facing
        if (other.CompareTag("Direction"))
        {
            playerDirection = other.name;
        }
    }
}

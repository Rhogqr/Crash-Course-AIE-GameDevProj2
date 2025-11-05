using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// i (reuben) didnt write this script, so comments may be a bit off

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    PlayerStatsManager pSM;
    MainDoorTest mDT;
    TaskDebuffAlien tDA;
    EyeStunAlien eSA;
    SineWaveAlt sWA;

    [SerializeField] AudioSource healSound;

    public float maxHealth = 100f;
    public float currentHealth;
    public float multiplier = 3f;
    float temp;
    
    // Start is called before the first frame update
    void Start()
    {
        // initialises the scripts of other objects for variables needed in this script
        pSM = GameObject.Find("PlayerStatsManager").GetComponent<PlayerStatsManager>();
        mDT = GameObject.Find("Vault_Door").GetComponent<MainDoorTest>();
        tDA = GameObject.Find("Task Guy Prototypes").GetComponent<TaskDebuffAlien>();
        eSA = GameObject.Find("Eye Prototypes").GetComponent<EyeStunAlien>();
        sWA = GameObject.Find("SineWaveAlt").GetComponent<SineWaveAlt>();

        // initialises variables
        temp = multiplier;

        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        // if the game is not over
        if (!pSM.isGameOver && mDT.progressCheck > 0)
        {
            // if the task alien is on the left, the health goes gown by 2x
            if (tDA.debuff2) multiplier = temp * 2f;
            else multiplier = temp;

            // health goes down by 1 per second times the multiplier
            currentHealth -= 1f * Time.deltaTime * multiplier;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
            UpdateHealthBar();
            // if the eye alien is not stunning the player and there is no sine wave comms failure, the player can heal by pressing E when facing left
            if (!eSA.isStunned && !sWA.commsFailure)
            {
                if (Input.GetKeyDown(KeyCode.E) && pSM.playerDirection == "Left")
                {
                    currentHealth += 2.5f;
                    healSound.Play();
                    UpdateHealthBar();
                }
            }
        }
    }

    private void UpdateHealthBar()
    {
        // updates the health bar fill amount based on current health
        healthBar.fillAmount = currentHealth / maxHealth;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
    }
}

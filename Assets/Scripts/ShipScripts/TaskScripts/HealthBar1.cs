using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    PlayerStatsManager pSM;
    MainDoorTest mDT;
    TaskDebuffAlien tDA;

    public float maxHealth = 100f;
    public float currentHealth;
    public float multiplier = 3f;
    float temp;
    
    // Start is called before the first frame update
    void Start()
    {
        pSM = GameObject.Find("PlayerStatsManager").GetComponent<PlayerStatsManager>();
        mDT = GameObject.Find("Vault_Door").GetComponent<MainDoorTest>();
        tDA = GameObject.Find("Task Guy Prototypes").GetComponent<TaskDebuffAlien>();
        temp = multiplier;

        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pSM.isGameOver && mDT.progressCheck > 0)
        {
            if (tDA.debuff2) multiplier = temp * 2f;
            else multiplier = temp;

            currentHealth -= 1f * Time.deltaTime * multiplier;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
            UpdateHealthBar();

            if (Input.GetKeyDown(KeyCode.E) && pSM.playerDirection == "Left")
            {
                currentHealth += 2.5f;
                UpdateHealthBar();
            }
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
    }
}

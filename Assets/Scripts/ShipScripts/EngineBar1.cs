using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class EngineBar : MonoBehaviour
{
    [SerializeField] private Image engineBar;

    PlayerStatsManager pSM;
    MainDoorTest mDT;
    TaskDebuffAlien tDA;
    EyeStunAlien eSA;

    public float maxEngine = 100f;
    public float currentEngine;
    public float multiplier = 3f;
    float temp;
    // Start is called before the first frame update
    void Start()
    {
        pSM = GameObject.Find("PlayerStatsManager").GetComponent<PlayerStatsManager>();
        mDT = GameObject.Find("Vault_Door").GetComponent<MainDoorTest>();
        tDA = GameObject.Find("Task Guy Prototypes").GetComponent<TaskDebuffAlien>();
        eSA = GameObject.Find("Eye Prototypes").GetComponent<EyeStunAlien>();
        temp = multiplier;

        currentEngine = maxEngine;
        UpdateEngineBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pSM.isGameOver && mDT.progressCheck > 0)
        {
            if (tDA.debuff1) multiplier = temp * 2f;
            else multiplier = temp;

            currentEngine -= 0.2f * Time.deltaTime * multiplier;
            currentEngine = Mathf.Clamp(currentEngine, 0f, maxEngine);
            UpdateEngineBar();

            if (!eSA.isStunned)
            {
                if (Input.GetKeyDown(KeyCode.E) && pSM.playerDirection == "Right")
                {
                    currentEngine += 2.5f;
                    UpdateEngineBar();
                }
            }
        }
    }

    private void UpdateEngineBar()
    {
        engineBar.fillAmount = currentEngine / maxEngine;
        currentEngine = Mathf.Clamp(currentEngine, 0f, maxEngine);
    }
}
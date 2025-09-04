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

    public float maxEngine = 100f;
    public float currentEngine;
    public float multiplier = 3f;

    // Start is called before the first frame update
    void Start()
    {
        pSM = GameObject.Find("PlayerStatsManager").GetComponent<PlayerStatsManager>();
        mDT = GameObject.Find("Vault_Door").GetComponent<MainDoorTest>();

        currentEngine = maxEngine;
        UpdateEngineBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pSM.isGameOver && mDT.progressCheck > 0)
        {
            currentEngine -= 0.2f * Time.deltaTime * multiplier;
            currentEngine = Mathf.Clamp(currentEngine, 0f, maxEngine);
            UpdateEngineBar();

            if (Input.GetKeyDown(KeyCode.E) && pSM.playerDirection == "Right")
            {
                currentEngine += 1.5f;
                UpdateEngineBar();
            }
        }
    }

    private void UpdateEngineBar()
    {
        engineBar.fillAmount = currentEngine / maxEngine;
        currentEngine = Mathf.Clamp(currentEngine, 0f, maxEngine);
    }
}

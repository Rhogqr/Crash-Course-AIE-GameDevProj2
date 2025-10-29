using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskDebuffAlien : MonoBehaviour
{
    public GameObject[] TaskGuys;
    [SerializeField] int taskGuysChance;
    public bool debuff1 = false;
    public bool debuff2 = false;

    // Start is called before the first frame update
    void Start()
    {
        // initialises all of them to be set inactive on start
        for (int i = 0; i < TaskGuys.Length; i++)
        {
            TaskGuys[i].gameObject.SetActive(false);
        }
        // starts the continuous checker to spawn them or not
        StartCoroutine(spawnCriteria());
    }

    // Update is called once per frame
    void Update()
    {
        // checks every frame if a task alien is up, to know whether or not to send the debuff out
        TaskAlienActiveCheck();
    }

    private void TaskAlienActiveCheck()
    {
        // if Right Task Guy (Sine Wave) is out, then speed up the Sine Wave's distortion
        if (TaskGuys[0].activeInHierarchy)
        {
            debuff1 = true;
        }
        else
        {
            debuff1 = false;
        }

        // if Left Task Guy (Health Bar) is out, then speed up that bar's drain
        if (TaskGuys[1].activeInHierarchy)
        {
            debuff2 = true;
        }
        else
        {
            debuff2 = false;
        }
    }

    IEnumerator spawnCriteria()
    {
        // every 5 seconds
        while(true)
        {
            yield return new WaitForSeconds(5f);
            // run a 1/[taskGuysChance] roll
            int rand = Random.Range(0, taskGuysChance);
            if (rand == 0)
            {
                // if chance is hit, then set one of the task guys to true
                int rand2 = Random.Range(0, 2);
                TaskGuys[rand2].gameObject.SetActive(true);
            }
        }
    }

    public void KillAlienR()
    {
        // button function, diables the right task alien
        TaskGuys[0].gameObject.SetActive(false);
    }

    public void KillAlienL()
    {
        // button function, diables the left task alien
        TaskGuys[1].gameObject.SetActive(false);
    }
}

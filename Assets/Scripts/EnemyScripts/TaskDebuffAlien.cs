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
        for (int i = 0; i < TaskGuys.Length; i++)
        {
            TaskGuys[i].gameObject.SetActive(false);
        }
        StartCoroutine(spawnCriteria());
    }

    // Update is called once per frame
    void Update()
    {
        TaskAlienActiveCheck();
    }

    private void TaskAlienActiveCheck()
    {
        if (TaskGuys[0].activeInHierarchy)
        {
            debuff1 = true;
        }
        else
        {
            debuff1 = false;
        }

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
        while(true)
        {
            yield return new WaitForSeconds(5f);
            int rand = Random.Range(0, taskGuysChance);
            if (rand == 0)
            {
                Debug.Log("errrm");
                int rand2 = Random.Range(0, 2);
                TaskGuys[rand2].gameObject.SetActive(true);
            }
        }
    }

    public void KillAlienR()
    {
        TaskGuys[0].gameObject.SetActive(false);
    }

    public void KillAlienL()
    {
        TaskGuys[1].gameObject.SetActive(false);
    }
}

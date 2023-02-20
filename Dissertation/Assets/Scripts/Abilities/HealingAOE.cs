using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingAOE : MonoBehaviour
{
    public GameObject HealingField;
    public Transform SpawnPos;
    public float CooldownTime;
    public bool canSpawn;
    public bool Activate;
    public Vector3 Scale;

    void Update()
    {
        if (Activate)
        {
            if (canSpawn == true)
            {
                InitField();
                canSpawn = false;
                StartCoroutine(CooldownTimer());
            }
        }
        else
        {
            canSpawn = true;
        }

        Debug.Log(Activate);
    }

    void InitField()
    {
        GameObject newField = Instantiate(HealingField);
        newField.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0, 0, 0);
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(CooldownTime);
        canSpawn = true;
        Activate = false;
    }
}

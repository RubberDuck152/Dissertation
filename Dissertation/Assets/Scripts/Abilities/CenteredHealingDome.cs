using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenteredHealingDome : MonoBehaviour
{
    public GameObject HealingArea;
    public GameObject newField;
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

            if (newField != null)
            {
                newField.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
            }
        }
        else
        {
            canSpawn = true;
        }
    }

    void InitField()
    {
        newField = Instantiate(HealingArea);
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(CooldownTime);
        canSpawn = true;
        Activate = false;
    }
}

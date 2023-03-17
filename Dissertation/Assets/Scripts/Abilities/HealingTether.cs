using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingTether : MonoBehaviour
{
    public GameObject healingTether;
    public GameObject newTether;
    public Transform SpawnPos;
    public float CooldownTime;
    public bool canSpawn;
    public bool Activate;
    public bool TargetAlly;

    void Update()
    {
        if (Activate)
        {
            if (canSpawn == true)
            {
                InitTether();
                canSpawn = false;
                StartCoroutine(CooldownTimer());
            }

            if (newTether != null)
            {
                newTether.transform.position = SpawnPos.position;
            }
        }
        else
        {
            canSpawn = true;
        }
    }


    void InitTether()
    {
        newTether = Instantiate(healingTether);
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(CooldownTime);
        Destroy(newTether);
        canSpawn = true;
        Activate = false;
    }
}

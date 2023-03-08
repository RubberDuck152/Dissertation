using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingTether : MonoBehaviour
{
    public ParticleSystem healingTether;
    public ParticleSystem newTether;
    public Transform SpawnPos;
    public float CooldownTime;
    public bool canSpawn;
    public bool Activate;
    public bool TargetAlly;
    public Vector3 Scale;
    public float radius;

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
                newTether.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;

                Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

                float closestAlly = Mathf.Infinity;
                Transform nearestAlly = null;
                foreach (Collider closeObject in colliders)
                {
                    if (closeObject.gameObject.layer == 6)
                    {
                        float Ally = Mathf.Min(closestAlly, Vector3.Distance(transform.position, closeObject.transform.position));
                        if (Ally < closestAlly)
                        {
                            closestAlly = Ally;
                            nearestAlly = closeObject.gameObject.transform;
                        }
                    }
                }

                if (nearestAlly)
                {
                    transform.LookAt(nearestAlly);
                    healingTether.startSpeed = closestAlly;
                }
                else
                {
                    healingTether.startSpeed = 0.1f;
                }
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
        canSpawn = true;
        Activate = false;
    }
}

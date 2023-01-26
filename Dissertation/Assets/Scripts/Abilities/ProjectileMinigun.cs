using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMinigun : MonoBehaviour
{
    public GameObject ProjectileObject;
    public GameObject newProjectile;
    public GameObject SpawnPos;

    public float ProjectileDamage;
    public float CooldownTime;
    public int NoOfProjectiles;
    public float DelayTime;
    public bool Delay;
    public bool canSpawn;
    public bool Activate;
    public Vector3 Scale;

    void Update()
    {
        if (Activate)
        {
            if (canSpawn == true)
            {
                InitProjectile();
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

    void InitProjectile()
    {
        int i = 0;
        while (i < NoOfProjectiles)
        {
            if (Delay == false)
            {
                newProjectile = Instantiate(ProjectileObject);
                newProjectile.transform.localScale = Scale;

                newProjectile.GetComponent<Projectile>().transform.position = SpawnPos.transform.position;

                newProjectile.GetComponent<Projectile>().MovementSpeed = (GameObject.FindGameObjectWithTag("Player").transform.forward * Time.deltaTime).normalized * 0.25f;

                newProjectile.GetComponent<Projectile>().DamageValue = ProjectileDamage;
                Delay = true;
                StartCoroutine(DelayTimer());
            }
        }
    }

    IEnumerator DelayTimer()
    {
        yield return new WaitForSeconds(DelayTime);
        Delay = false;
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(CooldownTime);
        canSpawn = true;
        Activate = false;
    }
}

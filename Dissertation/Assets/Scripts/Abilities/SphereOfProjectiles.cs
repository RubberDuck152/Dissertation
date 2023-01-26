using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereOfProjectiles : MonoBehaviour
{
    public GameObject ProjectileObject;
    public GameObject newProjectile;
    public GameObject SpawnPos;

    public float ProjectileDamage;
    public float CooldownTime;
    public int NoOfProjectiles;
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
            int DirectionIntX = Random.Range(-360, 360);
            int DirectionIntY = Random.Range(-360, 360);
            int DirectionIntZ = Random.Range(-360, 360);
            newProjectile = Instantiate(ProjectileObject);
            newProjectile.transform.localScale = Scale;

            newProjectile.GetComponent<Projectile>().transform.position = SpawnPos.transform.position;

            newProjectile.GetComponent<Projectile>().MovementSpeed = (new Vector3(DirectionIntX, DirectionIntY, DirectionIntZ) * Time.deltaTime).normalized * 0.005f;

            newProjectile.GetComponent<Projectile>().DamageValue = ProjectileDamage;
            i++;
        }
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(CooldownTime);
        canSpawn = true;
        Activate = false;
    }
}

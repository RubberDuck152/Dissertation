using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveProjectile : MonoBehaviour
{
    public GameObject ProjectileObject;
    public Transform SpawnPos;
    public Transform cam;

    public float ProjectileDamage;
    public float CooldownTime;
    public float MovementSpeedX;
    public float MovementSpeedY;
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
    }

    void InitProjectile()
    {
        GameObject newProjectile = Instantiate(ProjectileObject, SpawnPos.position, cam.rotation);
        newProjectile.transform.localScale = Scale;

        Vector3 movement = cam.transform.forward * MovementSpeedX + transform.up * MovementSpeedY;

        newProjectile.GetComponent<Rigidbody>().AddForce(movement, ForceMode.Impulse);
        newProjectile.GetComponent<Projectile>().DamageValue = ProjectileDamage;
        newProjectile.GetComponent<Projectile>().explosive = true;
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(CooldownTime);
        canSpawn = true;
        Activate = false;
    }
}

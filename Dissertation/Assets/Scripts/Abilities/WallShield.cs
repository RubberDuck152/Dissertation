using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallShield : MonoBehaviour
{
    public GameObject ShieldObject;
    public GameObject newShield;
    public GameObject HoverPos;

    public float ShieldHealth;
    public float ShieldHealthMax;
    public float ShieldDuration;
    public float ShieldRespawnTimer;
    public bool canSpawn;
    public bool Activate;

    private void Start()
    {
        canSpawn = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Activate)
        {
            if (canSpawn == true)
            {
                newShield = Instantiate(ShieldObject);
                Debug.Log("ShieldSpawned");
                StartCoroutine(ShieldDurationTimer());
            }

            if (newShield != null)
            {
                newShield.transform.position = HoverPos.transform.position;
                newShield.transform.rotation = HoverPos.transform.rotation;
            }

            if (canSpawn == false)
            {
                if (ShieldHealth <= 0)
                {
                    Destroy(newShield);
                    newShield = null;
                    StartCoroutine(RespawnTimer());
                }
            }
        }
        else
        {
            Destroy(newShield);
            newShield = null;
            canSpawn = true;
            ShieldHealth = ShieldHealthMax;
        }
    }

    IEnumerator ShieldDurationTimer()
    {
        canSpawn = false;
        yield return new WaitForSeconds(ShieldDuration);
        Destroy(newShield);
        newShield = null;
        StartCoroutine(RespawnTimer());
    }

    IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(ShieldRespawnTimer);
        canSpawn = true;
        Activate = false;
        ShieldHealth = ShieldHealthMax;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyProjectile")
        {
            ShieldHealth = ShieldHealth - gameObject.GetComponent<Projectile>().DamageValue;
            Destroy(other.gameObject);
        }
    }
}

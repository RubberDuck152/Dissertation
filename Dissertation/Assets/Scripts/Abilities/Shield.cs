using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject ShieldObject;
    public GameObject newShield;

    [Header("Shield Variant 1 Stats")]

    public GameObject ShieldVariant1;
    public float ShieldHealthVariant1;
    public float ShieldHealthMaxVariant1;
    public float ShieldDurationVariant1;
    public float ShieldRespawnTimerVariant1;

    [Header("Shield Variant 2 Stats")]

    public GameObject ShieldVariant2;
    public float ShieldHealthVariant2;
    public float ShieldHealthMaxVariant2;
    public float ShieldDurationVariant2;
    public float ShieldRespawnTimerVariant2;

    [Header("Shield Variant 3 Stats")]

    public GameObject ShieldVariant3;
    public float ShieldHealthVariant3;
    public float ShieldHealthMaxVariant3;
    public float ShieldDurationVariant3;
    public float ShieldRespawnTimerVariant3;

    [Header("Active Shield Health")]

    public float ShieldHealth;
    public float ShieldHealthMax;
    public float ShieldDuration;
    public float ShieldRespawnTimer;
    public bool canSpawn;
    public bool Activate;
    public int ChosenShield;

    private void Start()
    { 
        canSpawn = true;

        switch (ChosenShield)
        {
            case 0:
                ShieldObject = ShieldVariant1;
                ShieldHealth = ShieldHealthVariant1;
                ShieldHealthMax = ShieldHealthMaxVariant1;
                ShieldDuration = ShieldDurationVariant1;
                ShieldRespawnTimer = ShieldRespawnTimerVariant1;
                break;
            case 1:
                ShieldObject = ShieldVariant2;
                ShieldHealth = ShieldHealthVariant2;
                ShieldHealthMax = ShieldHealthMaxVariant2;
                ShieldDuration = ShieldDurationVariant2;
                ShieldRespawnTimer = ShieldRespawnTimerVariant2;
                break;
            case 2:
                ShieldObject = ShieldVariant3;
                ShieldHealth = ShieldHealthVariant3;
                ShieldHealthMax = ShieldHealthMaxVariant3;
                ShieldDuration = ShieldDurationVariant3;
                ShieldRespawnTimer = ShieldRespawnTimerVariant3;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //if (GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerController>().DefenseToggleNum == 0)
        //{

            if (Activate)
            {
                if (canSpawn == true)
                {
                    newShield = Instantiate(ShieldObject);
                    newShield.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
                    Debug.Log("ShieldSpawned");
                    StartCoroutine(ShieldDurationTimer());
                }
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
        //}
        //else
        //{
           // Destroy(newShield);
            //newShield = null;
            //canSpawn = true;
            //ShieldHealth = ShieldHealthMax;
        //}
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
        ShieldHealth = ShieldHealthMax;
    }
}


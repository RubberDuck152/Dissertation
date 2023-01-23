using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject ShieldObject;
    public GameObject newShield;



    public GameObject ShieldVariant1;
    public GameObject ShieldVariant2;
    public GameObject ShieldVariant3;
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
                break;
            case 1:
                ShieldObject = ShieldVariant2;
                break;
            case 2:
                ShieldObject = ShieldVariant3;
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


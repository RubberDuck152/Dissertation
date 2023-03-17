using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public Text spawnText;
    public Transform[] spawnPoints;
    public GameObject enemy;
    bool canSpawn = false;
    bool timerReset;

    private void Update()
    {
        if (canSpawn == true && timerReset == false)
        {
            GameObject enemy1 = Instantiate(enemy, spawnPoints[0].transform);
            GameObject enemy2 = Instantiate(enemy, spawnPoints[1].transform);
            GameObject enemy3 = Instantiate(enemy, spawnPoints[2].transform);
            canSpawn = false;
            StartCoroutine(Timer());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            spawnText.text = "Press T to Spawn Enemies";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButton("T"))
            {
                canSpawn = true;
            }
            spawnText.text = "Press T to Spawn Enemies";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            spawnText.text = "";
        }
    }

    IEnumerator Timer()
    {
        timerReset = true;
        yield return new WaitForSeconds(20.0f);
        timerReset = false;
    }
}

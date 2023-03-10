using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingTetherTargeting : MonoBehaviour
{
    public float radius;
    public float maxRange;
    public float Ally;
    public ParticleSystem healingTether;
    GameObject[] entities;

    private void Start()
    {
        entities = GameObject.FindGameObjectsWithTag("Ally");
    }

    [System.Obsolete]
    void Update()
    {
        float closestAlly = Mathf.Infinity;
        Transform nearestAlly = null;
        foreach (GameObject closeObject in entities)
        {
            if (closeObject.gameObject.layer == 6)
            {
                Ally = Mathf.Min(closestAlly, Vector3.Distance(transform.position, closeObject.transform.position));
                if (Ally < closestAlly && Ally <= maxRange)
                {
                    closestAlly = Ally;
                    nearestAlly = closeObject.gameObject.transform;
                }
            }
        }

        if (nearestAlly != null && Ally <= maxRange)
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

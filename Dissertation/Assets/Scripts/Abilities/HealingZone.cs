using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    public bool CanHeal = false;
    public bool TickHealing = true;
    public float HealAmount;
    public float FieldDuration;
    public float HealIntervals;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        StartCoroutine(DestroyField());
        if (CanHeal == true)
        {
            if (TickHealing == true)
            {
                if (player.GetComponent<CharacterMovement>().CurrentPlayerHP < player.GetComponent<CharacterMovement>().MaxPlayerHP)
                {
                    StartCoroutine(HealReset());
                }
            }
        }
    }

    IEnumerator HealReset()
    {
        TickHealing = false;
        player.GetComponent<CharacterMovement>().CurrentPlayerHP += HealAmount;
        yield return new WaitForSeconds(HealIntervals);
        TickHealing = true;
        Debug.Log("Heal reset");
    }

    IEnumerator DestroyField()
    {
        yield return new WaitForSeconds(FieldDuration);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CanHeal = true;
            Debug.Log("Healing is true");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            CanHeal = true;
            Debug.Log("Healing is true");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CanHeal = false;
            Debug.Log("Healing is false");
        }
    }
}

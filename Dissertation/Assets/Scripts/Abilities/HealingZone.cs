using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    public bool CanHealPlayer = false;
    public bool CanHealAlly = false;
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
        if (CanHealPlayer == true)
        {
            if (TickHealing == true)
            {
                if (player.GetComponent<CharacterMovement>().CurrentPlayerHP < player.GetComponent<CharacterMovement>().MaxPlayerHP)
                {
                    StartCoroutine(HealReset());
                }
            }
        }

        if (CanHealAlly == true)
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
            CanHealPlayer = true;
            Debug.Log("Healing is true");
        }

        if (other.tag == "Ally")
        {
            CanHealAlly = true;
            Debug.Log("Healing is true");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            CanHealPlayer = true;
            Debug.Log("Healing is true");
        }

        if (other.tag == "Ally")
        {
            CanHealAlly = true;
            Debug.Log("Healing is true");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CanHealPlayer = false;
            Debug.Log("Healing is false");
        }

        if (other.tag == "Ally")
        {
            CanHealAlly = false;
            Debug.Log("Healing is false");
        }
    }
}

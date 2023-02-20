using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    bool CanHeal = false;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Heal();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Heal();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Heal();
        }
    }

    void Heal()
    {
        if (CanHeal == true)
        {
            if (player.GetComponent<CharacterMovement>().CurrentPlayerHP < player.GetComponent<CharacterMovement>().MaxPlayerHP)
            {
                player.GetComponent<CharacterMovement>().CurrentPlayerHP += HealAmount;
                StartCoroutine(HealReset());
            }
        }
    }

    IEnumerator HealReset()
    {
        yield return new WaitForSeconds(HealIntervals);
        CanHeal = true;
    }

    IEnumerator DestroyField()
    {
        yield return new WaitForSeconds(FieldDuration);
        Destroy(gameObject);
    }
}

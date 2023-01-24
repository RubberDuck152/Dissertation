using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveShield : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            //GameObject.FindGameObjectWithTag("GameController").GetComponent<Shield>().ShieldHealth =
                //GameObject.FindGameObjectWithTag("GameController").GetComponent<Shield>().ShieldHealth - other.GetComponent<Projectile>().DamageValue;
            Destroy(other.gameObject);
        }
    }
}

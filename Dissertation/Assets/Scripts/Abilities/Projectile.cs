using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float DamageValue;
    public float DelayTime;
    public float radius;
    public float explosionForce;
    public bool explosive;

    void Update()
    {
        StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(DelayTime);
        Destroy(gameObject);
    }

    void Explosion()
    {
        if (explosive)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider closeObject in colliders)
            {
                Rigidbody rb = closeObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, radius);
                    Destroy(gameObject);
                }

                if (closeObject.tag == "Player")
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().CurrentPlayerHP -= DamageValue/2;
                    Destroy(gameObject);
                    DelayTime = 0;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explosion();

        if (collision.gameObject.layer == 6)
        {
            collision.gameObject.GetComponent<CharacterMovement>().CurrentPlayerHP -= DamageValue;
            StartCoroutine(DestroyObject());
            DelayTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            if (other.tag == "BubbleShield")
            {
                GameObject.FindGameObjectWithTag("Abilities").GetComponent<BubbleShield>().ShieldHealth -= DamageValue;
            }

            if (other.tag == "WallShield")
            {
                GameObject.FindGameObjectWithTag("Abilities").GetComponent<WallShield>().ShieldHealth -= DamageValue;
            }

            if (other.tag == "DomeShield")
            {
                GameObject.FindGameObjectWithTag("Abilities").GetComponent<DomeShield>().ShieldHealth -= DamageValue;
            }

            StartCoroutine(DestroyObject());
            DelayTime = 0;
        }
    }
}

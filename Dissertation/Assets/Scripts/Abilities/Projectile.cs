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
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explosion();
    }
}

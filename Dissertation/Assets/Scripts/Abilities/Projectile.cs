using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 MovementSpeed;
    public float DamageValue;
    public float DelayTime;

    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(MovementSpeed, ForceMode.Impulse);
        StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(DelayTime);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public float CooldownTime;
    public bool canFly;
    public bool Activate;
    public float maxFlightTime;
    float flightTime = 0;
    bool isFlying;
    
    CharacterController charControls;
    CharacterMovement charMove;
    Animator anim;

    private void Start()
    {
        charControls = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        charMove = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    void Update()
    {
        Debug.Log(anim.gameObject.name);
        Debug.Log(anim.gravityWeight);
        Debug.Log(anim.velocity);
        if (Activate)
        {
            if (canFly == true)
            {
                anim.applyRootMotion = false;
                canFly = false;
                isFlying = true;
                StartCoroutine(Flight());
                StartCoroutine(CooldownTimer());
            }
        }
        else
        {
            canFly = true;
        }
    }

    IEnumerator Flight()
    {
        while (isFlying)
        {
            charMove.groundedPlayer = true;
            if (Input.GetButtonDown("Jump"))
            {
                Vector3 cancelGravity = new Vector3(0f, 9.81f, 0f);
                charControls.Move(cancelGravity * Time.deltaTime);
            }
            Debug.Log(charControls.velocity);
            if (Input.GetButtonDown("Crouch"))
            {
                Vector3 cancelGravity = new Vector3(0f, -9.81f, 0f);
                charControls.Move(cancelGravity * Time.deltaTime);
            }
            yield return null;

            flightTime += Time.deltaTime;
            if (flightTime >= maxFlightTime)
            {
                isFlying = false;
            }
        }
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(CooldownTime);
        canFly = true;
        Activate = false;
        anim.applyRootMotion = true;
    }
}

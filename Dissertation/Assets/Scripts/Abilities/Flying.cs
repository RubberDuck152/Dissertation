using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public float CooldownTime;
    public bool canFly;
    public bool Activate;
    public float maxFlightTime;
    public float tempPlayerSpeed;
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
        if (Activate)
        {
            if (canFly == true)
            {
                anim.applyRootMotion = false;
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
        if (isFlying)
        {
            Vector3 cancelGravity = new Vector3(0f, 9.81f, 0f);
            charMove.groundedPlayer = true;
            charMove.playerSpeed = tempPlayerSpeed;
            if (Input.GetButton("Jump"))
            {
                cancelGravity = new Vector3(0f, 9.81f, 0f);
                charControls.Move(cancelGravity * Time.deltaTime);
            }
            if (Input.GetButton("Crouch"))
            {
                cancelGravity = new Vector3(0f, -9.81f, 0f);
                charControls.Move(cancelGravity * Time.deltaTime);
            }
            yield return null;
        }
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(CooldownTime);
        isFlying = false;
        canFly = false;
        Activate = false;
        anim.applyRootMotion = true;
        charMove.playerSpeed = 2.0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public float CooldownTime;
    public bool canFly;
    public bool Activate;
    CharacterController charControls;
    CharacterMovement charMove;

    private void Start()
    {
        charControls = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        charMove = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
    }

    void Update()
    {
        if (Activate)
        {
            if (canFly == true)
            {
                canFly = false;

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
        if (charControls.isGrounded == false)
        {
            charMove.groundedPlayer = true;
            Vector3 cancelGravity = new Vector3(0f, 9.81f, 0f);
            charControls.Move(cancelGravity);

            if (Input.GetButtonDown("Crouch"))
            {
                charMove.playerVelocity.y += Mathf.Sqrt((float)(charMove.jumpHeight * 3.0f * -9.81));
            }
        }

        yield return new WaitForSeconds(CooldownTime);

        if (charControls.isGrounded == false)
        {
            charMove.groundedPlayer = false;
        }
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(CooldownTime);
        canFly = true;
        Activate = false;
    }
}

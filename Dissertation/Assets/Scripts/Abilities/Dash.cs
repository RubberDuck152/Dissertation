using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float CooldownTime;
    public bool canDash;
    public bool Activate;
    public float dashForce;
    public float dashForceUp;
    public float dashDuration;
    CharacterController charController;
    public Transform orientation;
    public Camera cam;
    Vector3 direction;

    private void Start()
    {
        charController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (verticalInput == 0 && horizontalInput == 0)
        {
            direction = cam.transform.forward;
        }
        else
        {
            direction = cam.transform.forward * verticalInput + cam.transform.right * horizontalInput;
        }

        if (Activate)
        {
            if (canDash == true)
            {
                canDash = false;

                StartCoroutine(Dashing());

                StartCoroutine(CooldownTimer());
            }
        }
        else
        {
            canDash = true;
        }
    }

    IEnumerator Dashing()
    {
        Vector3 dashVector = direction * dashForce + orientation.up * dashForceUp;
        charController.Move(dashVector);
        yield return new WaitForSeconds(dashDuration);
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(CooldownTime);
        canDash = true;
        Activate = false;
    }
}

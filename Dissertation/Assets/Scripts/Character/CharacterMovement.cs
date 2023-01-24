using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;

    public GameObject Weapon;
    public GameObject empowermentParticle;
    public GameObject AbilityUI;
    public Image AbilitySlot1;
    public Image AbilitySlot2;
    public Image AbilitySlot3;

    public Transform cam;

    public Animator anim;
    private Hashing hash;

    public bool armed = false;
    private bool groundedPlayer;
    private bool MenuTimer = false;

    public float playerSpeed = 2.0f;
    public float jumpHeight = 2.0f;
    public float turnSmoothTime = 0.1f;
    public float speedDampTime = 0.01f;
    public float jumpForce;
    public int PlayerHP = 20;
    public int respawnTimer;

    public string FirstAbilityButton;
    public string SecondAbilityButton;
    public string ThirdAbilityButton;
    public string AbilitySelectorMenu;

    private float gravityValue = -9.81f;

    float turnSmoothVelocity;

    private Vector3 movementVector;
    private Vector3 playerVelocity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<Hashing>();

        anim?.SetLayerWeight(1, 1f);
    }

    void Update()
    {
        if (PlayerHP > 0)
        {
            if (Input.GetButtonDown("Draw Weapon"))
            {
                armed = !armed;
            }
            // Checks to see if the player is grounded
            if (controller.isGrounded)
            {
                groundedPlayer = true;
            }

            if (groundedPlayer && playerVelocity.y < 0)
            {
                movementVector = Vector3.zero;
                playerVelocity.y = 0f;
            }

            // Gets all the Input values from the keyboard / controller
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            bool jump = Input.GetButtonDown("Jump");

            // Creates a new Vector3 to move the player
            Vector3 direction = new Vector3(horizontal, 0.0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
                anim?.SetBool(hash.movingBool, true);
            }
            else
            {
                anim?.SetBool(hash.movingBool, false);
            }

            // Jumping for the Player Character
            if (jump && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                anim?.SetBool(hash.jumpBool, true);
                anim?.SetBool(hash.fallingBool, true);
                if (groundedPlayer)
                {
                    anim?.SetBool(hash.landingBool, true);
                }

                groundedPlayer = false;
            }
            else
            {
                anim?.SetBool(hash.rollBool, false);
                anim?.SetBool(hash.jumpBool, false);
            }

            if (armed == false)
            {
                Weapon.SetActive(false);
                anim?.SetBool(hash.armedBool, false);

                if (Input.GetButtonDown("Main Attack"))
                {
                    anim?.SetBool(hash.attack1Bool, true);
                }
                else
                {
                    anim?.SetBool(hash.attack1Bool, false);
                }
            }
            else
            {
                Weapon.SetActive(true);
                anim?.SetBool(hash.armedBool, true);

                if (Input.GetButtonDown("Main Attack"))
                {
                    anim?.SetBool(hash.attack1Bool, true);

                }
                else
                {
                    anim?.SetBool(hash.attack1Bool, false);
                }
            }

            if (Input.GetButtonDown(FirstAbilityButton))
            {
                AbilitySlot1.GetComponent<ActiveAbilitySlot1>().ActivateAbility = true;
            }
            else
            {
                AbilitySlot1.GetComponent<ActiveAbilitySlot1>().ActivateAbility = false;
            }

            if (Input.GetButtonDown(SecondAbilityButton))
            {
                AbilitySlot2.GetComponent<ActiveAbilitySlot2>().ActivateAbility = true;
            }
            else
            {
                AbilitySlot2.GetComponent<ActiveAbilitySlot2>().ActivateAbility = false;
            }

            if (Input.GetButtonDown(ThirdAbilityButton))
            {
                AbilitySlot3.GetComponent<ActiveAbilitySlot3>().ActivateAbility = true;
            }
            else
            {
                AbilitySlot3.GetComponent<ActiveAbilitySlot3>().ActivateAbility = false;
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
            // Maintains the velocity whilst jumping however unable to change direction
            controller.Move(movementVector);
        }

        if (PlayerHP <= 0)
        {
            anim?.SetBool(hash.deathBool, true);
            StartCoroutine(Respawn());
        }

        if (MenuTimer == false && AbilityUI.activeSelf == false)
        {
            if (Input.GetButtonDown(AbilitySelectorMenu))
            {
                AbilityUI.SetActive(true);
                AbilitySlot1.GetComponent<Image>().enabled = true;
                AbilitySlot1.gameObject.GetComponentInChildren<Image>().enabled = true;
                AbilitySlot2.GetComponent<Image>().enabled = true;
                AbilitySlot3.GetComponent<Image>().enabled = true;
                MenuTimer = true;
                StartCoroutine(MenuDelay());
            }
        }

        if (AbilityUI.activeSelf == true && MenuTimer == false)
        {
            if (Input.GetButtonDown(AbilitySelectorMenu))
            {
                AbilityUI.SetActive(false);
                AbilitySlot1.GetComponent<Image>().enabled = false;
                AbilitySlot2.GetComponent<Image>().enabled = false;
                AbilitySlot3.GetComponent<Image>().enabled = false;
                MenuTimer = true;
                StartCoroutine(MenuDelay());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTimer);
        PlayerHP = 20;
        anim?.SetBool(hash.deathBool, false);
    }

    IEnumerator MenuDelay()
    {
        yield return new WaitForSeconds(0.2f);
        MenuTimer = false;
    }
}

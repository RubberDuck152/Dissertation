using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject player;
    public GameObject projectile;
    public GameObject ProjectileSpawnPos;
    public Vector3 projectileScale;
    public float rotationSpeed;
    public float movementSpeed;
    public float stoppingDistance;
    public float attackDistance;
    public float projectileMovementSpeedX;
    public float projectileMovementSpeedY;
    public float fireRate;
    public float maxHP;
    public float currentHP;
    public float DMG;

    public bool move = false;
    public bool spotted = false;
    public bool attacked = false;
    public bool knockback = false;

    int timer = 0;

    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
    private bool isWandering = false;
    private bool attackCooldown = false;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Enemy Target");
        navMeshAgent.stoppingDistance = stoppingDistance;
    }

    private void Update()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().CurrentPlayerHP <= 0)
        {
            spotted = false;
        }

        if (spotted == true)
        {
            navMeshAgent.stoppingDistance = stoppingDistance;
            if (move)
            {
                navMeshAgent.destination = player.transform.position;
            }

            if (distanceFromPlayer <= attackDistance)
            {
                if (attackCooldown == false)
                {
                    attackCooldown = true;
                    StartCoroutine(Attack());
                }
            }

            if (distanceFromPlayer <= stoppingDistance)
            {
                move = false;
            }
            else
            {
                move = true;
            }
        }
        else
        {
            navMeshAgent.stoppingDistance = stoppingDistance;
            if (isWandering == false)
            {
                StartCoroutine(Roaming());
            }

            if (isRotatingRight == true)
            {
                transform.Rotate(transform.up * Time.deltaTime * rotationSpeed * 50);
            }

            if (isRotatingLeft == true)
            {
                transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed * 50);
            }

            if (isWalking == true)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * movementSpeed);
            }
        }

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }

        if (Vector3.Distance(transform.position, player.transform.position) <= (stoppingDistance + 2))
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().anim.GetCurrentAnimatorStateInfo(0).IsName("Armed-Attack-1"))
            {
                if (timer == 0)
                {
                    currentHP = currentHP - GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().SwordDMG;
                    knockback = true;
                    timer = 1;
                    StartCoroutine(TimeDelay(1));
                }
            }

            if (GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().anim.GetCurrentAnimatorStateInfo(0).IsName("Unarmed-Attack-1"))
            {
                if (timer == 0)
                {
                    currentHP = currentHP - GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().FistDMG;
                    knockback = true;
                    timer = 1;
                    StartCoroutine(TimeDelay(1));
                }
            }
        }

        if (knockback == true)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3((transform.position.x - player.transform.position.x),
                2.0f, (transform.position.z - player.transform.position.z)).normalized, ForceMode.Impulse);
        }
    }

    void LateUpdate()
    {
        if (spotted == true)
        {
            Vector3 targetDirection = player.transform.position - transform.position;
            targetDirection.y = Vector3.zero.y;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            spotted = true;
            move = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            spotted = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        spotted = false;
        move = false;
    }

    IEnumerator TimeDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        timer = 0;
        knockback = false;
    }

    IEnumerator Roaming()
    {
        int RotationTime = Random.Range(1, 4);
        int RotateWait = Random.Range(1, 4);
        int RotateDirection = Random.Range(1, 2);
        int WalkWait = Random.Range(1, 5);
        int WalkTime = Random.Range(1, 4);

        isWandering = true;

        yield return new WaitForSeconds(WalkWait);

        isWalking = true;

        yield return new WaitForSeconds(WalkTime);

        isWalking = false;

        yield return new WaitForSeconds(RotateWait);

        if (RotateDirection == 1)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(RotationTime);
            isRotatingLeft = false;
        }

        if (RotateDirection == 2)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(RotationTime);
            isRotatingRight = false;
        }

        isWandering = false;
    }

    IEnumerator Attack()
    {
        if (player.transform.position.y > transform.position.y)
        {
            projectileMovementSpeedY = (player.transform.position.y - transform.position.y) * 2;
        }
        else if (player.transform.position.y < transform.position.y)
        {
            projectileMovementSpeedY = (transform.position.y - player.transform.position.y) / 2;
        }

        GameObject newProjectile = Instantiate(projectile, ProjectileSpawnPos.transform.position, ProjectileSpawnPos.transform.rotation);
        newProjectile.transform.localScale = projectileScale;
        newProjectile.GetComponent<Projectile>().DamageValue = DMG;

        Vector3 movement = transform.forward * projectileMovementSpeedX + transform.up * projectileMovementSpeedY;

        newProjectile.GetComponent<Rigidbody>().AddForce(movement, ForceMode.Impulse);
        yield return new WaitForSeconds(0.1f);

        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(fireRate);
        attackCooldown = false;
    }
}

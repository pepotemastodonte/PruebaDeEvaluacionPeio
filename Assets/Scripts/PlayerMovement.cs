using UnityEngine;
using System;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public int force;
    public int healthPoints = 100;
    public int currentHealth;

    private float h;
    private float v;
    private float iFrame;

    private Vector3 movement;

    [SerializeField]
    private Transform weapon;

    [SerializeField]
    private GameObject bullet;

    Rigidbody rigidbody;

    GameOver gameOver;

    UIScript uIScript;

    HealthSpawner healthSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        iFrame = 0;

        rigidbody = GetComponent<Rigidbody>();

        gameOver = FindAnyObjectByType<GameOver>();

        uIScript = FindAnyObjectByType<UIScript>();

        healthSpawner = FindAnyObjectByType<HealthSpawner>();

        currentHealth = healthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        iFrame += Time.deltaTime;

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");


        movement = new Vector3(h, 0 ,v) * speed;

        /*float angle = Mathf.Atan2(movement.x, movement.z); //No funciona
        Debug.Log(angle);
        transform.rotation = Quaternion.Euler(0, angle, 0);*/

        Quaternion targetRotation = Quaternion.LookRotation(movement);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);

        rigidbody.MovePosition(rigidbody.position + movement * Time.deltaTime);

        if (Input.GetMouseButtonDown(0) && uIScript.canContinue)
        {
            Shoot();
        }

        if(currentHealth <= 0)
        {
            gameOver.GameEnding();
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(bullet, weapon.transform.position , Quaternion.identity);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        rb.AddForce(weapon.transform.forward * force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Equals("Enemy(Clone)") && iFrame >= .75)
        {
            currentHealth -= 5;
            iFrame = 0;
        }
        if(collision.gameObject.name.Equals("HealthPickUp(Clone)"))
        {
            HealPlayer();
            healthSpawner.RevomeHealth(collision.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name.Equals("Enemy(Clone)") && iFrame >= .75)
        {
            currentHealth -= 5;
            iFrame = 0;
        }
    }

    private void HealPlayer()
    {
        currentHealth += 20;
        if(currentHealth >= healthPoints)
        {
            currentHealth = healthPoints;
        }
    }
}

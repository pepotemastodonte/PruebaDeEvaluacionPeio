using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public int force;
    public int healthPoints = 100;

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
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        iFrame = 0;

        rigidbody = GetComponent<Rigidbody>();

        gameOver = FindAnyObjectByType<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {
        iFrame += Time.deltaTime;

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        movement = new Vector3(h, 0 ,v) * speed;
       
        rigidbody.MovePosition(rigidbody.position + movement * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if(healthPoints <= 0)
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
            healthPoints -= 5;
            iFrame = 0;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name.Equals("Enemy(Clone)") && iFrame >= .75)
        {
            healthPoints -= 5;
            iFrame = 0;
        }
    }
}

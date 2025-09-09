using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public int force;
    public int healthPoints = 100;

    private float h;
    private float v;

    private Vector3 movement;

    [SerializeField]
    private Transform weapon;

    [SerializeField]
    private GameObject bullet;

    Rigidbody rigidbody;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        movement = new Vector3(h, 0 ,v) * speed;
       
        rigidbody.MovePosition(rigidbody.position + movement * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
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
        if(collision.gameObject.name.Equals("Enemy(Clone)"))
        {
            healthPoints -= 5;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name.Equals("Enemy(Clone)"))
        {
            healthPoints -= 5;
        }
    }
}

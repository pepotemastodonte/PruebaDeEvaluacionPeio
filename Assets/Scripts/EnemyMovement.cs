using UnityEngine;
using UnityEngine.Rendering;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private float timer;

    private Vector3 randomPosition; 

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 1;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1.5)
        {
            randomPosition = new Vector3(Random.Range(-5f, 5f), 0.5f, (Random.Range(-5f, 5f))) * speed;
            timer = 0;
        }

        rb.MovePosition(rb.position + randomPosition * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name.Equals("Bullet(Clone)"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}

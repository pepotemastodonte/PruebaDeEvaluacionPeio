using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timer;

    MeshCollider meshCollider;

    [SerializeField]
    GameObject enemy;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0;
        meshCollider = GetComponent<MeshCollider>();    
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= .5)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-20f, 20f), 1f, (Random.Range(-20f, 20f)));

            Instantiate(enemy, randomPosition, Quaternion.identity);

            timer = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    private int healthCount = 1;

    [SerializeField]
    GameObject health;

    private List<GameObject> spawnedHealth = new List<GameObject>();

    UIScript UIScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIScript = FindAnyObjectByType<UIScript>();
        StartCoroutine(SpawnHealth());
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedHealth.Count == 0 && UIScript.canContinue)
        {
            //StartCoroutine(SpawnHealth());
        }
    }

    private IEnumerator SpawnHealth()
    {
            int dealy = Random.Range(5, 20);

            Vector3 randomPosition = new Vector3(Random.Range(-20f, 20f), 1f, (Random.Range(-20f, 20f)));

            yield return new WaitForSeconds(dealy);

            GameObject healthPickup = Instantiate(health, randomPosition, Quaternion.identity);

            spawnedHealth.Add(healthPickup);

            Debug.Log(spawnedHealth.Count);
    }
    public void RevomeHealth(GameObject health)
    {
        spawnedHealth.Remove(health);
    }
}

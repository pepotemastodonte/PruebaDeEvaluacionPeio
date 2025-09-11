using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    private int waveNumber = 1;
    public int WaveIndicator { get { return waveNumber; } set { waveNumber = value; } }

    private List<GameObject> spawnedEnemy = new List<GameObject>();

    [SerializeField]
    GameObject enemy;

    UIScript UIScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RoundStart();
        UIScript = FindAnyObjectByType<UIScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedEnemy.Count == 0 && UIScript.canContinue)
        {
            waveNumber++;
            RoundStart();
        }
    }

    void RoundStart()
    {
        for (int i = 0; i < waveNumber; i++)
        {

            Vector3 randomPosition = new Vector3(Random.Range(-20f, 20f), 1f, (Random.Range(-20f, 20f)));

            GameObject roundEnemy = Instantiate(enemy, randomPosition, Quaternion.identity);

            spawnedEnemy.Add(roundEnemy);
        }
    }

    public void RevomeEnemy(GameObject enemy)
    {
        spawnedEnemy.Remove(enemy);
    }
}

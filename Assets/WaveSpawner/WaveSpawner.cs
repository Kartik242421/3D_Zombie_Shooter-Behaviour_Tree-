using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;

    private Wave currentWave;

    [SerializeField] private Transform[] wavespawns;

    private float timebtspawns;
    private int i = 0;
    private bool stopspawn = false;

    private void Awake()
    {
        currentWave = waves[i];
        timebtspawns = currentWave.TimeBeforeThisWave;
    }


    // Update is called once per frame
    void Update()
    {
        if (stopspawn) { return; }

        if (Time.time >= timebtspawns)
        {
            SpawnWave();
            IncWave();

            timebtspawns = Time.time + currentWave.TimeBeforeThisWave;
        }
    }

    private void SpawnWave()
    {
        for (int i = 0; i < currentWave.NumberToSpawn; i++)
        {
            int num = Random.Range(0, currentWave.EnemiesInWave.Length);
            int num2 = Random.Range(0, wavespawns.Length);

            Instantiate(currentWave.EnemiesInWave[num], wavespawns[num2].position, wavespawns[num2].rotation);
        }
    }

    private void IncWave()
    {
        if (i + 1 < waves.Length)
        {
            i++;
            currentWave = waves[i];
        }
        else
        {
            stopspawn = true;
        }
    }
}

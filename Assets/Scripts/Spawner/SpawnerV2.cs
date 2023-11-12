using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnerV2 : MonoBehaviour
{
    [SerializeField] private float countdown;

    [SerializeField] private GameObject spawnPoint;


    private float randomSpawnZone;
    private float randomXposition, randomYposition;

    private Vector3 spawnPosition;
    private int randomParameter;

    [SerializeField] private int currentDays;

    [SerializeField] private Day[] days;

    [SerializeField] private int currentWaveIndex = 0;
    [SerializeField] private bool readyToCountdown;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {

        readyToCountdown = true;
        for (int i = 0; i < days[0].waves.Length; i++)
        {
            days[0].waves[i].enemiesLeft = days[0].waves[i].enemies.Length;
        }
    }







    private void Update()
    {
        SpawnNewEnemy();

        if (currentWaveIndex >= days[currentDays].waves.Length)
        {
            Debug.Log("GG");

        }

        if (readyToCountdown == true)
        {
            countdown -= Time.deltaTime;

        }

        if (countdown <= 0)
        {
            readyToCountdown = false;
            countdown = days[currentDays].waves[currentWaveIndex].timeToNextEnemy;

            StartCoroutine(SpawnWave());
        }
        if (days[currentDays].waves[currentWaveIndex].enemiesLeft == 0)
        {
            Debug.Log("tes");
            currentWaveIndex++;
            readyToCountdown = true;
        }

        if (currentWaveIndex == 6 && currentDays < days.Length)
        {
            currentWaveIndex = 0;
            currentDays++;
        }
    }

    private void SpawnNewEnemy()
    {
        randomSpawnZone = Random.Range(0, 4);

        switch (randomSpawnZone)
        {
            case 0:
                randomXposition = Random.Range(-20f, -19f);
                randomYposition = Random.Range(-15f, -15f);
                break;

            case 1:
                randomXposition = Random.Range(-19f, 19f);
                randomYposition = Random.Range(-14f, -15f);
                break;
            case 2:
                randomXposition = Random.Range(20f, 19f);
                randomYposition = Random.Range(-15f, 15f);
                break;
            case 3:
                randomXposition = Random.Range(-20f, 19f);
                randomYposition = Random.Range(14f, 15f);
                break;

        }
        spawnPosition = new Vector3(randomXposition, randomYposition, 0f);
    }

    private IEnumerator SpawnWave()
    {
        if (currentWaveIndex < days[currentDays].waves.Length)
        {
            for (int i = 0; i < days[currentDays].waves[currentWaveIndex].enemies.Length; i++)
            {
                Debug.Log(days[currentDays].waves[currentWaveIndex].enemiesLeft);
                Instantiate(days[currentDays].waves[currentWaveIndex].enemies[i], spawnPosition, Quaternion.identity);
                days[currentDays].waves[currentWaveIndex].enemiesLeft--;

                yield return new WaitForSeconds(days[currentDays].waves[currentWaveIndex].timeToNextEnemy);

            }

        }

    }

    [System.Serializable]
    public class Wave
    {
        public GameObject[] enemies;
        public float timeToNextEnemy;

        public float timeToNextWave;

        [HideInInspector] public int enemiesLeft;
    }

    [System.Serializable]
    public class Day
    {
        public Wave[] waves;
    }
}

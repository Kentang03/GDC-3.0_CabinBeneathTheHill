using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct WaveInfo
    {
        public string waveName;
        public GameObject enemyPrefabs;
        public int count;
    }



    public WaveInfo[] waveInfo;


    [SerializeField]
    private GameObject[] enemy;

    private GameObject mewEnemy;

    private float randomSpawnZone;
    private float randomXposition, randomYposition;
    private Vector3 spawnPosition;
    private int randomParameter;
    private Transform target;

    private float timeUntilSpawn;

    [SerializeField] private float SpawnSpeed = 5f;


    [SerializeField] private float targetingRange = 5f;
    // Start is called before the first frame update

    void Start()
    {
        InvokeRepeating("SpawnNewEnemy", 5f, 1f / SpawnSpeed);
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


        randomParameter = Random.Range(0, enemy.Length);
        spawnPosition = new Vector3(randomXposition, randomYposition, 0f);
        mewEnemy = Instantiate(enemy[randomParameter], spawnPosition, Quaternion.identity);
        Debug.Log(randomParameter);

    }





    private bool CheckTargetIsRange()
    {
        // Debug.Log("ADA MUSUH");

        return Vector2.Distance(target.position, transform.position) <= targetingRange;

    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.blue;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}

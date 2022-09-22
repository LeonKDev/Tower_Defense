using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSystem : MonoBehaviour
{
    public Transform[] WayPoints;
    public GameObject EnemyPrefab;

    public Transform SpawnPoint;

    public float TimeInterval = 5f;
    public float countdown = 2f;

    private int WaveIndex = 0;
    private void Update()
    {
       
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = TimeInterval;
        }

        countdown -= Time.deltaTime;
    }


    IEnumerator SpawnWave()
    {
        WaveIndex++;
        for (int i = 0; i < WaveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
    void SpawnEnemy()
    {
        GameObject obj = Instantiate(EnemyPrefab, SpawnPoint.position, Quaternion.identity);
        obj.GetComponent<EnemyPath>().WayPoints = WayPoints;

    }
}

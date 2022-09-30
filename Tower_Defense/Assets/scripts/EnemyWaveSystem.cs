using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSystem : MonoBehaviour
{
    public Transform[] WayPoints;
    public GameObject EnemyPrefab;

    public Transform SpawnPoint;

    
    public bool StartWave;
    public bool ClearedWave;

    private int WaveIndex = 0;
    //private bool start;

    private void Start()
    {
        StartWave = false;
        InvokeRepeating("checkEnemys", 0f, 0.5f);
    }
    private void Update()
    {
       
        if (StartWave && ClearedWave) 
        {
            StartCoroutine(SpawnWave());
            StartWave = false;
            ClearedWave = false;
        }

        
    }


    IEnumerator SpawnWave()
    {
        WaveIndex++;
        for (int i = 0; i < WaveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.4f);
        }
    }

    public void OnButtonClick()
    {
        StartWave = true;
    }
    void SpawnEnemy()
    {
        GameObject obj = Instantiate(EnemyPrefab, SpawnPoint.position, Quaternion.identity);
        obj.GetComponent<EnemyPath>().WayPoints = WayPoints;

    }

    void checkEnemys()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 )
        {
            ClearedWave = true;
        }
    }
    
    

}

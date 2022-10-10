using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyWaveSystem : MonoBehaviour
{
    public TextMeshProUGUI enemyCounter;
    private int enemyCount;

    public Transform[] WayPoints;
    public GameObject[] EnemyPrefab;
   

    public Transform SpawnPoint;

    
    public bool StartWave;
    public bool ClearedWave;

    private int WaveIndex = 0;
    //private bool start;

    private void Start()
    {
        
        StartWave = false;
        InvokeRepeating("CheckEnemys", 0f, 0.2f);
        InvokeRepeating("EnemyCounter", 0f, 0.2f);
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
        GameObject obj = Instantiate(EnemyPrefab[Random.Range(0, EnemyPrefab.Length)], SpawnPoint.position, Quaternion.identity);
        obj.GetComponent<EnemyBehaviour>().WayPoints = WayPoints;

    }

    void CheckEnemys()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 )
        {
            ClearedWave = true;
        }
    }

    void EnemyCounter()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyCounter.text = $"enemys remaining {enemyCount}";
    }
    
    

}

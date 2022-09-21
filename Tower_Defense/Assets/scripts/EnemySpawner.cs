using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] WayPoints;
    public GameObject EnemyPrefab;
    public int amountToSpawn;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (amountToSpawn > 0)
        {
            GameObject obj = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            obj.GetComponent<EnemyPath>().WayPoints = WayPoints;
        }
    }
}

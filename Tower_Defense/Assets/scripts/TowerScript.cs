using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    GameObject BulletSpawnPoint;
    GameObject BulletPrefab;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject == GameObject.FindWithTag("Enemy"))
        {
            Instantiate(BulletPrefab, BulletSpawnPoint.transform);
        }
        
    }
}

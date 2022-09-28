using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTower : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab = null;
    private Camera cam = null;
    

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        SpawnTowerAtMousePos();
    }
    private void SpawnTowerAtMousePos()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(towerPrefab, new Vector3(hit.point.x, hit.point.y + towerPrefab.transform.position.y, hit.point.z), Quaternion.identity);
            }
        }
        
     
    }
}

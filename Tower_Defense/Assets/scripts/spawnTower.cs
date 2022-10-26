using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnTower : MonoBehaviour
{
    public GameObject[] towerPrefab;
    public GameObject Tower;
    private Camera cam = null;
    public bool Bought;
    private int TowerType;

    currency currencyScript;
    public int SubAmount;
    public int SubAmount1;



    private void Start()
    {
        cam = Camera.main;
        Bought = false;
        currencyScript = FindObjectOfType<currency>();
    }

    public void OnButtonClick(int towertype)
    {
        TowerType = towertype;
        
        if (towerPrefab[towertype] == towerPrefab[0] && currencyScript.gold >= SubAmount)
        {
            
            Tower = Instantiate(towerPrefab[towertype]);
            Debug.Log(Tower.GetComponent<TowerScript>().placed);
            Tower.GetComponent<TowerScript>().placed = false;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Tower.transform.position = new Vector3(hit.point.x, hit.point.y + towerPrefab[towertype].transform.position.y, hit.point.z);
                //Tower.GetComponent<TowerScript>().placed = false;
            }  
            currencyScript.gold -= SubAmount;
            Bought = true;
        }

        if (towerPrefab[towertype] == towerPrefab[1] && currencyScript.gold >= SubAmount1)
        {
            
            Tower = Instantiate(towerPrefab[towertype]);
            Tower.GetComponent<TowerScript>().placed = false;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Tower.transform.position = new Vector3(hit.point.x, hit.point.y + towerPrefab[towertype].transform.position.y, hit.point.z);

            }
            currencyScript.gold -= SubAmount1;
            Bought = true;
        }
        
    }

    private void Update()
    {
        if (Bought)
        {
            SpawnTowerAtMousePos();
        }
       
    }

    private void SpawnTowerAtMousePos()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) && !hit.collider.gameObject.CompareTag("Placeable"))
            {
                Destroy(Tower);
            }
            else
            {
                Tower.transform.GetChild(1).gameObject.layer = 0;
            }
                Bought = false;  
                Tower.GetComponent<TowerScript>().placed = true;
        }
        else
        {
            if (Physics.Raycast(ray, out hit))
            {
                Tower.transform.position = new Vector3(hit.point.x, hit.point.y + towerPrefab[TowerType].transform.position.y, hit.point.z);
            }

            if (!hit.collider.gameObject.CompareTag("Placeable"))
            {
                ChangeColor(Color.red);
            }

            else
            {
                ChangeColor(Color.white);
            }           
        }

        void ChangeColor(Color color)
        {
            Tower.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material.color = color;
            Tower.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = color;
            Tower.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material.color = color;
        }
    }
}

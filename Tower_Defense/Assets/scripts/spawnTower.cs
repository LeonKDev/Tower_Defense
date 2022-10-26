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
    //TowerScript towerScript;

    currency currencyScript;
    public int SubAmount;
    public int SubAmount1;



    private void Start()
    {
        cam = Camera.main;
        Bought = false;
        currencyScript = FindObjectOfType<currency>();
        //towerScript = FindObjectOfType<TowerScript>();
    }

    public void OnButtonClick(int towertype)
    {
        TowerType = towertype;
        //towerScript.placed = false;

        if (towerPrefab[towertype] == towerPrefab[0] && currencyScript.gold >= SubAmount)
        {
            
            Tower = Instantiate(towerPrefab[towertype]);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Tower.transform.position = new Vector3(hit.point.x, hit.point.y + towerPrefab[towertype].transform.position.y, hit.point.z);
            }  
             currencyScript.gold -= SubAmount;
             Bought = true;
        }

        if (towerPrefab[towertype] == towerPrefab[1] && currencyScript.gold >= SubAmount1)
        {
            
            Tower = Instantiate(towerPrefab[towertype]);
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
            //towerScript.placed = true;

            if (Physics.Raycast(ray, out hit) && !hit.collider.gameObject.CompareTag("Placeable"))
            {
                Destroy(Tower);
            }
            else
            {
                Tower.transform.GetChild(1).gameObject.layer = 0;
            }
                Bought = false;
            
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

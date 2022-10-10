using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnTower : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab = null;
    public GameObject Tower;
    private Camera cam = null;
    public bool Bought;

    private void Start()
    {
        cam = Camera.main;
        Bought = false;
    }

    public void OnButtonClick()
    {
        Bought = true;
        Tower = Instantiate(towerPrefab);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Tower.transform.position = new Vector3(hit.point.x, hit.point.y + towerPrefab.transform.position.y, hit.point.z);

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
        }
        else
        {
            if (Physics.Raycast(ray, out hit))
            {
                Tower.transform.position = new Vector3(hit.point.x, hit.point.y + towerPrefab.transform.position.y, hit.point.z); 
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

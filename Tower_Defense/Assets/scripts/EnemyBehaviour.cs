using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    public float Health;
    public float startHealth = 100;

    private int point = 0;
    public Transform[] WayPoints;

    endPoint endpointScript;
    public Image fill;
   
    void Start()
    {
        Health = startHealth;

        endpointScript = FindObjectOfType<endPoint>();
        transform.position = WayPoints[point].transform.position;
        transform.LookAt(WayPoints[point].position);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
       
        transform.position = Vector3.MoveTowards(transform.position,WayPoints[point].transform.position, speed * Time.deltaTime);
        transform.LookAt(WayPoints[point].position);

        if (transform.position == WayPoints[point].position)
        {
            point += 1;
        }

        if (point == WayPoints.Length)
        {
            endpointScript.health -= 1;
            Destroy(gameObject);
        }  
    }
}


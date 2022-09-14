using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] private float speed;
    private int point = 0;
    [SerializeField] private Transform[] WayPoints;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = WayPoints[point].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move(); 

    }

    private void Move()
    {
      transform.position = Vector3.MoveTowards(transform.position,WayPoints[point].transform.position, speed * Time.deltaTime); 

        if (transform.position == WayPoints[point].position)
        {
            point += 1;
        }

        if (point == WayPoints.Length)
        {
            point = 0;
        }
        
    }
}


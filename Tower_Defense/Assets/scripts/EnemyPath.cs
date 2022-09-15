using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] private float speed;
    private int point = 0;
    [SerializeField] private Transform[] WayPoints;


    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
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
            
            Destroy(gameObject);
        }
        
    }
}


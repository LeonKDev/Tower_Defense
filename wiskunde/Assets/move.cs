using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject A;
    public GameObject B;
    public Vector3 verschil;
    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        A = GameObject.Find("A");
        B = GameObject.Find("B");
        Debug.Log(A.transform.position);
        Debug.Log(B.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        verschil = A.transform.position - B.transform.position;
        transform.position = B.transform.position + verschil * Mathf.Sin(time) * Mathf.Sin(time);
        time += Time.deltaTime;
    }
}

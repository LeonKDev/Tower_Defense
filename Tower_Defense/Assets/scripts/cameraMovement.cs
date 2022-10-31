using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
 
    private bool doMovement = true;

    public float CamSpeed = 6f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 50f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }
        if (!doMovement)
        {
            return;
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.forward * CamSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.back * CamSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.right * CamSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.left * CamSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

    }
}


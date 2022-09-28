using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public GameObject ImpactEffect;

    public float speed;

    public void seek(Transform _Target)
    {
        target = _Target;
    }

    void Update()
    {
      if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        
        transform.Translate (dir.normalized * distanceThisFrame, Space.World);

        
    }
    void HitTarget()
    {
        GameObject effectIns = (GameObject) Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1f);
        Destroy(gameObject);
        Destroy(target.gameObject);
    }
}

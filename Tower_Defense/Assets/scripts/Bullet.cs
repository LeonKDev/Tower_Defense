using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

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
    }

}

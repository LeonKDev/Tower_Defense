using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endPoint : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI towerHealth;
    public float health;

    private void Update()
    {
        RemaingHealth();
    }

    // Update is called once per frame


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health -= 1f;
        }
    }

    void RemaingHealth()
    {
        towerHealth.text = $"Remaining Health {health}";
    }
}

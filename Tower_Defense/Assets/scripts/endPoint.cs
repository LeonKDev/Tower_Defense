using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class endPoint : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI towerHealth;
    public int health;

    private void Update()
    {
        RemaingHealth();
    }
  
    void RemaingHealth()
    {
        towerHealth.text = $"{health}";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class endPoint : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI towerHealth;
    public int health;

    private void Update()
    {
        if (health == 0)
        {
            SceneManager.LoadScene("EndScreen");
        }
        RemaingHealth();
    }
  
    void RemaingHealth()
    {
        towerHealth.text = $"{health}";
    }


}

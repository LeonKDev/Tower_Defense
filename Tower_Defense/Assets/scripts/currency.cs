using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class currency : MonoBehaviour
{
    public int gold;

    [SerializeField] TextMeshProUGUI currencyUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currencyUI.text = gold.ToString();
        if (gold < 0)
        {
            gold = 0;
        }
    }
}

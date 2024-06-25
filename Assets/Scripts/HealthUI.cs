using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    private TextMeshProUGUI _healthText;
    
    private void Start()
    {
        _healthText = GetComponent<TextMeshProUGUI>();
        _healthText.text = stats.health.ToString();
    }

    public void UpdateHealthText(PlayerStats stats)
    {
        _healthText.text = stats.health.ToString();
    }
}

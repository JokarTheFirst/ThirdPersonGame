using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    public float health = 100f;
    public UnityEvent<PlayerStats> OnDamageTake;
    public UnityEvent<PlayerStats> OnDeath;

    private void Start()
    {
        
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        OnDamageTake.Invoke(this);
        
        if (health <= 0)
        {
            Destroy(gameObject);
            OnDeath.Invoke(this);
        }
    }
}

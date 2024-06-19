using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    public float health = 100f;
    public UnityEvent<PlayerStats> OnDamageTake;
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            OnDamageTake.Invoke(this);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


public class HealthPowerUp : MonoBehaviour
{
    public float healAmount = 20f;

    public GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
            
        }
    }

    private void Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.health += healAmount;
        if (stats.health > 100) stats.health = 100;
        stats.TakeDamage(0);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtObstacle : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit!");
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            playerStats.TakeDamage(damage);
        }
        

    }
}

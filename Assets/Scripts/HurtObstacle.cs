using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            Debug.Log("Get Hurt!");
            playerStats.TakeDamage(10);
        }

;    }
}

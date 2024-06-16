using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float multiplier = 1.4f;

    public GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        Instantiate(pickupEffect,transform.position, transform.rotation);

        player.transform.localScale *= multiplier;

        Destroy(gameObject);
    }
}

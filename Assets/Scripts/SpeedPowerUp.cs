using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeedPowerUp : MonoBehaviour
{
    public float multiplier = 1.4f;

    public GameObject pickupEffect;

    public float duration = 4;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        Instantiate(pickupEffect,transform.position, transform.rotation);

        PlayerStats stats = player.GetComponent<PlayerStats>();
        stats.health *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.health /= multiplier;

        Destroy(gameObject);
    }
}

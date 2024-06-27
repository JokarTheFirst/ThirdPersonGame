using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeedPowerUp : MonoBehaviour
{
    public float multiplier = 1.4f;

    public GameObject pickupEffect;
    public GameObject mesh;

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

        PlayerController stats = player.GetComponent<PlayerController>();
        stats.speed *= multiplier;

        mesh.SetActive(false);
        GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.speed /= multiplier;

        Destroy(gameObject);
    }
}

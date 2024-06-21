using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    [SerializeField] private float _triggerForce = 7f;
    [SerializeField] private float _explosionRadius = 0.5f;
    [SerializeField] private float _explosionForce = 500f;
    [SerializeField] private float _explosionDamage = 100f;
    [SerializeField] private GameObject _particles;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            PlayerStats stats = collision.GetComponent<PlayerStats>();

            if (playerController.currentSpeed >= _triggerForce)
            {
                
                stats.TakeDamage(_explosionDamage);


                var surrondingObjects = Physics.OverlapSphere(transform.position, _explosionRadius);

                foreach (var obj in surrondingObjects)
                {
                    var rigidBody = obj.GetComponent<Rigidbody>();
                    if (rigidBody == null) continue;

                    rigidBody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
                }

                Instantiate(_particles, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int damage { get; set; } = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}

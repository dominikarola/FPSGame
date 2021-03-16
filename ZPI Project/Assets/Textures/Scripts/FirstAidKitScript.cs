using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKitScript : MonoBehaviour
{
    Vector3 rotationDirection = new Vector3();
    Health playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            playerHealth = other.GetComponent<Health>();
            playerHealth.Heal(50);
        }
    }

    void Update()
    {
        rotationDirection.z = 0.25f;
        transform.Rotate(rotationDirection);
    }
}

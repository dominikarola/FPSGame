using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCollectibleScript : MonoBehaviour
{
    Vector3 rotationDirection = new Vector3();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            other.GetComponentInChildren<AmmoMagazine>().PickAmmo(20);
        }
    }

    void Update()
    {
        rotationDirection.y = 0.25f;
        transform.Rotate(rotationDirection);
    }
}

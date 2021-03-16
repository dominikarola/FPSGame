using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AmmoMagazine))]
public class HandgunFire : MonoBehaviour
{
    public GameObject theGun;
    public GameObject flash;
    public AudioSource gunFire;
    public bool isFiring = false;
    private AmmoMagazine magazine;
    public int gunDamage = 20;

    public float gunRange = 300.0f;

    public Camera fpsCamera;

    private void Start()
    {
        magazine = GetComponent<AmmoMagazine>();
    }
    private void Update()
    {
        if (!Pause.IsPaused)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if(isFiring == false)
                {
                    if (magazine.Fire())
                    {
                        StartCoroutine(FiringHandgun());
                        RaycastHit hit;
                        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.TransformDirection(Vector3.forward), out hit, gunRange))
                        {
                            var turret = hit.collider.gameObject.GetComponent<TurretScript>();
                            if (turret) {
                                turret.TakeDamage(gunDamage);
                            }
                        }
                    }
                }
            
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                magazine.Reload();
            }
        }
    }

    IEnumerator FiringHandgun()
    {
        isFiring = true;
        theGun.GetComponent<Animator>().Play("HandgunFire");
        flash.SetActive(true);
        gunFire.Play();
        yield return new WaitForSeconds(0.05f);
        flash.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        theGun.GetComponent<Animator>().Play("New State");
        isFiring = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [Tooltip("Moveable head")]
    [SerializeField]
    private GameObject turrethead = null;

    [Tooltip("Turret range")]
    [Range(0, 100)]
    [SerializeField]
    private float range = 5;

    [Tooltip("Turret head rotation speed")]
    [SerializeField]
    private float rotationSpeed = 1.0f;


    [Tooltip("Time between each bullet")]
    [SerializeField]
    private float shootTime = 2;
    private float actualShootTime = 0;

    [Tooltip("Start speed of shot the bullet")]
    [SerializeField]
    private float shotBulletSpeed = 750;

    [Tooltip("Time after which bullet will be automatically destroyed ")]
    [SerializeField]
    private float bulletDestroyTime = 4;

    [Tooltip("Prefab bullet")]
    [SerializeField]
    private GameObject prefabBullet;

    [Tooltip("Transform where next bullets are going to appear")]
    [SerializeField]
    private Transform bulletSpawner;

    [Tooltip("Minimum angle that turret needs be rotated to player before shoots")]
    [SerializeField]
    private float minAngleRotatedToPlayer = 1;

    private float angleToPlayer;

    [Tooltip("Turret max health")]
    [SerializeField]
    private int maxHealth = 20;
    public int currentHealth;

    [Tooltip("Turret's damage")]
    [SerializeField]
    private int damage = 20;

    private GameObject player;

    void OnDrawGizmosSelected()
    {
        // Draw a wire sphere at the transform's position displaying turret range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange())
        {
            rotateTowardsPlayer();
            shootting();
        }
        cooldowns();
        checkTurretHealth();
    }

    void checkTurretHealth() {
        if (currentHealth <= 0) {
            Destroy(this.gameObject);
        }  
    }


    bool playerInRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    void rotateTowardsPlayer()
    {
        if (turrethead != null)
        {
            Vector3 targetDirection = player.transform.position - turrethead.transform.position;
            turrethead.transform.rotation = Quaternion.Lerp(
                turrethead.transform.rotation, 
                Quaternion.LookRotation(targetDirection), 
                Time.deltaTime * rotationSpeed);
            angleToPlayer = Vector3.Angle(targetDirection, turrethead.transform.forward);
        }
    }

    void cooldowns()
    {
        // shoot time
        actualShootTime += Time.deltaTime;
    }

    void shootting() {
        if (actualShootTime >= shootTime && angleToPlayer <= minAngleRotatedToPlayer && angleToPlayer >= -minAngleRotatedToPlayer)
        {
            GameObject bullet = Instantiate(prefabBullet, bulletSpawner.position, bulletSpawner.rotation);
            bullet.GetComponent<BulletScript>().damage = damage;
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * shotBulletSpeed;
            Destroy(bullet, bulletDestroyTime);
            actualShootTime = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}

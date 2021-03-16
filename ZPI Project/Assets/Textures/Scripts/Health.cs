using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth = 100;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }

    public void Heal(int points)
    {
        currentHealth += points;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        healthBar.setHealth(currentHealth);
    }

    private void Update()
    {
        // Restart scene when player dies
        if (currentHealth <= 0) {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}

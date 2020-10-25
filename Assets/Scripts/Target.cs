
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public int health = 50;
    public ParticleSystem damage;
    public HealthBar healthBar;
    public Player player;
    public GameObject ammo;
    public GameObject healthDrop;
    int ran;

    void Awake()
    {
        healthBar.SetMaxHealth(health);
    }

    public void TakeDamage (int amount)
    {
        damage.Play();
        health -= amount;
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            player.IncreaseScore(1);
            Die();
        }
    }

    void Die()
    {
        ran = Random.Range(0, 20);
        if(ran<6)
        {
            Instantiate(ammo, transform.position, Quaternion.identity);
        }
        if(ran==19)
        {
            Instantiate(healthDrop, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}

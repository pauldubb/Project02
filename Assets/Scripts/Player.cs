
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;

    public int score;
    public Text scoreText;

    public GameObject uiObject;
    public HealthBar healthBar;
    public Gun gun;

    Collider _colliderToDeactivate = null;

    void Awake()
    {

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        _colliderToDeactivate = GetComponent<Collider>();
        uiObject.SetActive(false);
    }

    void LateUpdate()
    {
        scoreText.text = "Score: " + score;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void Damage()
    {
        currentHealth--;
        healthBar.SetHealth(currentHealth);
    }

    public void Heal()
    {
        currentHealth++;
        if(currentHealth>maxHealth)
        {
            currentHealth = 4;
        }
        healthBar.SetHealth(currentHealth);
    }

    public void RefillAmmo(int ammo)
    {
        gun.IncreaseAmmo(ammo);
    }

    public void IncreaseScore(int scoreIncrease)
    {
        score += scoreIncrease;
    }

    public int GetScore()
    {
        return score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public GameObject uiObject;
    public HealthBar healthBar;

    Collider _colliderToDeactivate = null;

    void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        _colliderToDeactivate = GetComponent<Collider>();
        uiObject.SetActive(false);
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

    public void Die()
    {
        UnityEngine.Debug.Log("Player has been killed!");
        _colliderToDeactivate.enabled = false;
        uiObject.SetActive(true);
    }
}

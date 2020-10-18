﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardVolume : MonoBehaviour
{
    //project 2
    [SerializeField] AudioClip _damageSound = null;
    [SerializeField] AudioClip _deathSound = null;

    private void Awake()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            if (player.GetHealth() == 1)
            {
                AudioHelper.PlayClip2D(_deathSound, 1);
                player.Die();
                DelayHelper.DelayAction(this, LoadDeath, 1f);
            }
            else
            {
                player.Damage();
                AudioHelper.PlayClip2D(_damageSound, 1);
            }
        }
    }

    void LoadDeath()
    {
        SceneManager.LoadScene("DeathScene");
    }

    void ReloadLevel()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }
}

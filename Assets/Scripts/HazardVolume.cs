using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardVolume : MonoBehaviour
{
    //project 2
    [SerializeField] AudioClip _deathSound = null;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            DontDestroyOnLoad(AudioHelper.PlayClip2D(_deathSound, 1));
            LoadDeath();
        }
    }

    void LoadDeath()
    {
        SceneManager.LoadScene("DeathScene");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardVolume : MonoBehaviour
{
    //project 2
    [SerializeField] AudioClip _damageSound = null;

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

                SceneManager.LoadScene("DeathScene");
            }
            else
            {
                player.Damage();
                AudioHelper.PlayClip2D(_damageSound, 1);
            }


            /*_flashImage.StartFlash(.25f, .5f, Color.red);
            uiObject.SetActive(true);
            AudioHelper.PlayClip2D(_deathSound, 1);
            deathParticle.Play();
            playerShip.Kill();
            DelayHelper.DelayAction(this, ReloadLevel, 2.0f);
            */
        }
    }

    void ReloadLevel()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }
}

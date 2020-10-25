using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    [SerializeField] AudioClip _damageSound = null;
    [SerializeField] AudioClip _deathSound = null;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            if (player.GetHealth() == 1)
            {
                DontDestroyOnLoad(AudioHelper.PlayClip2D(_deathSound, .5f));
                LoadDeath();
            }
            else
            {
                player.Damage();
                AudioHelper.PlayClip2D(_damageSound, .5f);
                Destroy(gameObject);
            }    
        }
        
        if(other.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }

    }

    void LoadDeath()
    {
        SceneManager.LoadScene("DeathScene");
    }
}

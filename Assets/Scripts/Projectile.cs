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
                AudioHelper.PlayClip2D(_deathSound, 1);
                player.Die();
                DelayHelper.DelayAction(this, LoadDeath, 1f);
            }
            else
            {
                player.Damage();
                AudioHelper.PlayClip2D(_damageSound, 1);
                Destroy(gameObject);
            }    
        }
        
        if(other.gameObject.name == "Plane")
        {
            Destroy(gameObject);
        }

    }

    void LoadDeath()
    {
        SceneManager.LoadScene("DeathScene");
    }
}

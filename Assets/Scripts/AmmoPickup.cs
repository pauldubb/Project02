using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            AudioHelper.PlayClip2D(clip, 1f);
            player.RefillAmmo(10);
            Destroy(gameObject);
        }
    }
}

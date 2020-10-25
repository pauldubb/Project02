
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;
    public float impactForce = 30f;
    public int ammo = 2000;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public AudioClip clip;
    public AudioClip emptyClip;
    public GameObject impactEffect;
    public Text ammoText;

    public Vector3 upRecoil;
    Vector3 originalRotation;

    void Awake()
    {
        originalRotation = transform.localEulerAngles;
    }
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && ammo>0)
        {
            Shoot();
        }
        else if(Input.GetButtonDown("Fire1") && ammo == 0)
        {
            AudioHelper.PlayClip2D(emptyClip, .5f);
        }
        ammoText.text = "Ammo: " + ammo.ToString();
    }

    void Shoot()
    {
        AudioHelper.PlayClip2D(clip, .5f);
        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Enemy")
            {
                Target target = hit.transform.GetComponent<Target>();
                target.TakeDamage(damage);
            }
            else if(hit.transform.tag=="Head")
            {
                Debug.Log("Headshot");
                Target target = hit.transform.GetComponentInParent<Target>();
                target.TakeDamage(30);
            }
            else
            {
                Debug.Log(hit.transform.name);
            }

            GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);

        }
        ammo--;
    }

    public void SetAmmo(int ammoSet)
    {
        ammo = ammoSet;

    }

    public void IncreaseAmmo(int ammoSet)
    {
        ammo += ammoSet;
    }

    private void AddRecoil()
    {
        transform.localEulerAngles += upRecoil;
    }

    private void StopRecoil()
    {
        transform.localEulerAngles = originalRotation;
    }
}

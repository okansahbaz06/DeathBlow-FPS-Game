using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

public class atesetme : MonoBehaviour { 

    public float reloadcooldown;
    public float AmmoInGun;
    public float AmmoInPocket;
    public float AmmoMax;
    float AddableAmmo;
    float reloadtimer;
    public Text AmmoCounter;
    public Text PocketAmmoCounter;

     

    public GameObject impactEffect;
    public GameObject BloodyimpactEffect;

    RaycastHit hit;
    public GameObject RayPoint;
    public CharacterController Karakter;

    Animator GunAnimset;
    public bool CamFire;
    float gunTimer;
    public float gunCooldown;
    public ParticleSystem MuzzleFlash;

    [Header("Oyun Sesleri")]
    AudioSource SesKaynak;
    public AudioClip FireSound;
    public float range;
    public int damage;
    
    public AudioClip ReloadSound;

    // Start is called before the first frame update
    void Start()
    {
        SesKaynak = GetComponent<AudioSource>();
        GunAnimset = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    GunAnimset.SetFloat("hiz", Karakter.velocity.magnitude);

    AmmoCounter.text = AmmoInGun.ToString();
    PocketAmmoCounter.text = AmmoInPocket.ToString();

    AddableAmmo = AmmoMax - AmmoInGun;
    if (AddableAmmo > AmmoInPocket)
    {
        AddableAmmo = AmmoInPocket;
    }

    if (Input.GetKeyDown(KeyCode.R) && AddableAmmo > 0 && AmmoInPocket > 0) 
    { 
        if(Time.time>reloadtimer)
        {
            StartCoroutine(Reload());
            reloadtimer = Time.time + reloadcooldown;
        }
    }

        if (Input.GetKey(KeyCode.Mouse0) && CamFire == true && Time.time > gunTimer && AmmoInGun>0)
        {
            Fire();
            gunTimer = Time.time + gunCooldown;
        }
    }

    void Fire()
    {
        AmmoInGun--;
        if (Physics.Raycast(RayPoint.transform.position, RayPoint.transform.forward, out hit, range))
        {
            MuzzleFlash.Play();
            SesKaynak.Play();
            SesKaynak.clip = FireSound;
            Debug.Log(hit.transform.name);

            GunAnimset.Play("fire", -1, 0f);

            if (hit.collider.tag == "Untagged")
            {
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }

            if (hit.collider.tag == "Enemy")
            {
                Instantiate(BloodyimpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                hit.collider.gameObject.transform.root.GetComponent<zombiescript>().health = hit.collider.gameObject.transform.root.GetComponent<zombiescript>().health - damage;

            }
            if(hit.collider.tag == "Enemy2")
            {
                Instantiate(BloodyimpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                hit.collider.gameObject.transform.root.GetComponent<spiderscript>().can = hit.collider.gameObject.transform.root.GetComponent<spiderscript>().can - damage;

            }
            zombiescript zs = hit.transform.GetComponent<zombiescript>();
            if(zs != null)
            {
                zs.can1(damage);
            }
            


        }
    }

    IEnumerator Reload()
    {
        GunAnimset.SetBool("isReloading", true);
        SesKaynak.clip = ReloadSound;
        SesKaynak.Play();

        yield return new WaitForSeconds(0.3f);
        GunAnimset.SetBool("isReloading", false);

        yield return new WaitForSeconds(1.4f);
        AmmoInGun = AmmoInGun + AddableAmmo;
        AmmoInPocket = AmmoInPocket - AddableAmmo;
    }
}

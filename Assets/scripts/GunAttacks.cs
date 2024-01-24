using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttacks : MonoBehaviour
{
    [SerializeField] private Gun Data;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject Gun;
    private float fireRate;
    private float reloadTime;
    private bool fireBullet = false;
    private bool reloading = false;
    private float startTime = 0f;
    private float nextFire;
    private int maxAmmo;
    private int currentAmmo;
    // Start is called before the first frame update
    void Start()
    {
        fireRate = Data.fireRate;
        maxAmmo = Data.gunAmmo;
        reloadTime = Data.reloadTime;
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {   
        if (DialogueManager.Instance.dialogueIsActive)
        {
            return;
        }
        
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            fireBullet = true;
        }
    }

    void FixedUpdate()
    {
        if (reloading)
        {
            if (Time.time - startTime > reloadTime)
            {
                currentAmmo = maxAmmo;
                reloading = false;
            }
            else
            {
                Debug.Log(Time.time - startTime);
            }
        }
        else if (currentAmmo < 1)
        {
            reloading = true;
            startTime = Time.time;
        }
        else if (fireBullet)
        {
            nextFire = Time.time + fireRate;
            GameObject thing = Instantiate(bullet, transform.position, transform.rotation);
            currentAmmo--;
            Debug.Log("bullet fired");
            fireBullet = false;
        }

    }
}

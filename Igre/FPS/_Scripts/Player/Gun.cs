using System;
using System.Collections;
using TMPro;
using UnityEngine;

public enum FireMode
{
    SingleFire,
    RapidFire,
    BurstFire
}

public class Gun : MonoBehaviour
{
    [SerializeField] private TMP_Text bulletText;

    [SerializeField] private GameObject[] guns;
    
     [Header("Gun Parameters")] [SerializeField]
     private float singleFireCooldown = 0.5f;
     [SerializeField] private float rapidFireCooldown = 0.1f;
     [SerializeField] private float burstFireCooldown = 0.1f;
     [SerializeField] private float burstDelay = 1;
     [SerializeField] private int burstCount = 3;
     [Header("Reloading")]
     [SerializeField] private float reloadCooldown = 1;
     [SerializeField] private int maxMagazineSize = 15;
     [SerializeField] private int currentMagazineSize;
     [SerializeField] private int maxAmmo = 45;
     
    [SerializeField] private Transform muzzle;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float minZoom = 60;
    [SerializeField] private float maxZoom = 30;
    
    
    private FireMode fireMode = FireMode.SingleFire;
    private bool canFire = true;
    private bool isFiring = false;
    private bool isReloading = false;
    private bool isZooming = false;
    int currentGunIndex;
    Camera playerCamera;

    private void Start()
    {
        playerCamera =  Camera.main;
        currentMagazineSize = maxMagazineSize;
        bulletText.text = $"{currentMagazineSize}/{maxAmmo}";
    }

    private void Update()
    {
        Shooting();
        WeaponZoom(); 
        Reloading();
        SwitchFireMode();

        // Switching weapons
        if (Input.mouseScrollDelta.y > 0)
        {
            currentGunIndex++;

            if (currentGunIndex >= guns.Length)
            {
                currentGunIndex = 0;
            }
            for (int i = 0; i < guns.Length; i++)
            {
                guns[i].SetActive(false);
            }

            guns[currentGunIndex].SetActive(true);
        }  
        
        if (Input.mouseScrollDelta.y < 0)
        {
            currentGunIndex--;
            if (currentGunIndex < 0)
            {
                currentGunIndex =  guns.Length - 1;
            }
            for (int i = 0; i < guns.Length; i++)
            {
                guns[i].SetActive(false);
            }

            guns[currentGunIndex].SetActive(true);
        }

    }

    private void Shooting()
    {
        if (Input.GetMouseButton(0) && canFire && !isFiring && !isReloading)
        {
            Fire();
            if (currentMagazineSize == 0 && !isReloading)
            {
                StartCoroutine(Reload());
                Debug.Log($"Reloading on mouse button");
            }
        }
    }

    private void WeaponZoom()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isZooming = !isZooming; // flip flop
            if (isZooming)
            {
                StartCoroutine(SetZoom(minZoom, maxZoom));

            }
            else
            {
                StartCoroutine(SetZoom(maxZoom, minZoom));
            }
        }
    }

    private void Reloading()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            Debug.Log($"Reloading");
            StartCoroutine(Reload());
        }
    }

    private void SwitchFireMode()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            fireMode = FireMode.SingleFire;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            fireMode = FireMode.RapidFire;
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            fireMode = FireMode.BurstFire;
        }
    }

    IEnumerator SetZoom(float start, float end)
    {
        float timer = 0;
        float elapse = 0.2f;
        while (timer < elapse )
        {
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            playerCamera.fieldOfView = Mathf.Lerp(start, end, timer/elapse);
        }
    }
    private void Fire()
    {
        switch (fireMode)
        {
            case FireMode.SingleFire:
                HandleSingleFire();
            break;
            case FireMode.RapidFire:
                HandleRapidFire();
                break;
            case FireMode.BurstFire:
                HandleBurstFire();
                break;
            default:
                Debug.LogError("Invalid FireMode");
                break;
                
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;

        yield return new WaitForSeconds(reloadCooldown);
        
        int ammoNeeded = maxMagazineSize - currentMagazineSize;
        if (maxAmmo > 0)
        {
            if (maxAmmo < ammoNeeded)
            {
                currentMagazineSize += maxAmmo;
                maxAmmo = 0;
            }
            else
            {
                currentMagazineSize += ammoNeeded;
                maxAmmo -= ammoNeeded;

            }
        }

        bulletText.text = $"{currentMagazineSize}/{maxAmmo}";
        isReloading = false;
    }

    private void HandleSingleFire()
    {
        CreateBullet();
        StartCooldown(singleFireCooldown);
    }

    private void HandleRapidFire()
    {
        CreateBullet();
        StartCooldown(rapidFireCooldown);
        
    }

    private void HandleBurstFire()
    {
        StartCoroutine(BurstFire());
    }

    IEnumerator BurstFire()
    {
        isFiring = true;
        for (int i = 0; i < burstCount; i++)
        {
            CreateBullet();
            yield return new WaitForSeconds(burstFireCooldown);
        }
        yield return new WaitForSeconds(burstDelay);
        isFiring = false;
    }

    private void CreateBullet()
    {
        if (currentMagazineSize > 0)
        {
            Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
            currentMagazineSize--;
        }
        bulletText.text = $"{currentMagazineSize}/{maxAmmo}";
        
    }

    private void StartCooldown(float cooldown)
    {
        StartCoroutine(CoolDown(cooldown));
    }

    IEnumerator CoolDown(float cooldown)
    {
        canFire = false;
        yield return new WaitForSeconds(cooldown);
        canFire = true;
    }
    
}

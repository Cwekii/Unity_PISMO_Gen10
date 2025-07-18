using System;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private TMP_Text bulletCountText;
    [SerializeField] private TMP_Text reloadText;
    
    
    [SerializeField] private Transform muzzle;
    [SerializeField] private Bullet bulletPrefab;
    
    private int bulletCount = 25;
    bool isReloading = false;

    [SerializeField] private float timer = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reloadText.text = String.Empty;
        bulletCountText.text = "Bullet: " + bulletCount;
    }

    // Update is called once per frame
    void Update()
    {
            timer -= Time.deltaTime;
       
        if (Input.GetMouseButtonDown(0) )
        {
            if (bulletCount > 0)
            {
                reloadText.text = String.Empty;
                //Shoot
                Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
                bulletCount--;
                if (bulletCount <= 0)
                {
                    reloadText.text = "Reload";
                }
                bulletCountText.text = "Bullet: " + bulletCount;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            isReloading = true;
            timer = 2;
            reloadText.text = "Reloading";
            
        }
        if (timer <= 0 && isReloading)
        {
            reloadText.text = String.Empty;
            Reload();
        }
    }

    private void Reload()
    {
        bulletCount = 25;
        isReloading = false;
        bulletCountText.text = "Bullet: " + bulletCount;
    }
}

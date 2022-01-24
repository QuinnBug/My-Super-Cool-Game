using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTurret : MonoBehaviour
{
    private float ammo;
    public float maxAmmo ;
    public float rotSpeed;
    public float targetterRange;
    [Space]
    public Transform targetter;
    [Space]
    public float shootingOffset;
    public GameObject bulletPrefab;
    public float bulletForce;
    public float reloadDuration;
    public float shotDelay;
    private float shotTimer;
    Vector3 cursorPos;
    Vector3 aimDir;
    [Space]
    internal bool reloading;

    // Start is called before the first frame update
    void Start()
    {
        ammo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        AimingCheck();

        if (shotTimer >= 0)
        {
            shotTimer -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Mouse0) && !reloading && shotTimer <= 0)
        {
            if (Shoot())
            {
                shotTimer = shotDelay;
            }
            else
            {
                Reload();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        Vector3 newDirection = targetter.position - transform.position;
        float angle = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    private void Reload()
    {
        if (reloading) return;
        ammo = 0;
        StartCoroutine(ReloadTimer());
    }

    private IEnumerator ReloadTimer()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadDuration);
        ammo = maxAmmo;
        reloading = false;
    }

    internal float GetAmmoPercent()
    {
        return ammo / maxAmmo;
    }

    internal float GetAmmo()
    {
        return ammo;
    }

    private void AimingCheck()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPos.z = 0;
        aimDir = transform.position + ((cursorPos - transform.position).normalized * targetterRange);
        targetter.position = aimDir;
    }

    private bool Shoot()
    {
        if (ammo <= 0) return false;

        ammo--;

        GameObject bullet = Instantiate(bulletPrefab, transform.position + (transform.up * shootingOffset), transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletForce);
        Destroy(bullet, 10);

        return true;
    }
}

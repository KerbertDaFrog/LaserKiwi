using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed;

    public int bulletAmount = 200;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;

    PlayerUI playerUI;

    // Start is called before the first frame update
    void Start()
    {
        playerUI = GetComponent<PlayerUI>();

        SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletAmount <= 0)
        {
            isFiring = false;
            return;
        }

        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <=0)
            {
                shotCounter = timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                newBullet.speed = bulletSpeed;
                bulletAmount -= 1;
                playerUI.ammoAmount.text = bulletAmount.ToString();
            }
            else
            {
                shotCounter = 0;
            }
        }
    }

    void SetStats()
    {
        playerUI.ammoAmount.text = bulletAmount.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultLaserGun : MonoBehaviour
{
        public GameObject bulletPrefab;
        private GameObject gunBulletSpawnPoint;
        private SpriteRenderer gunSprite;
        public float fireRate = 0.3f;

    private void Start() {
        gunBulletSpawnPoint = transform.Find("BulletSpawnPoint").gameObject;
        gunSprite = GetComponent<SpriteRenderer>();
    }
    private void Update() {
        Shoot();
    }
        void Shoot(){
        if(Input.GetMouseButtonDown(0))
        {
            InvokeRepeating("Fire", 0.05f, fireRate);
        }
        if(Input.GetMouseButtonUp(0))
        {
            CancelInvoke("Fire");
        }
    }

    void Fire(){
        GameObject bullet = Instantiate(bulletPrefab, gunBulletSpawnPoint.transform.position, gunBulletSpawnPoint.transform.rotation);
        Destroy(bullet, 2f);
    }
}

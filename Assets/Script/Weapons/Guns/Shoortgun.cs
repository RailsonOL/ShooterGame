using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoortgun : MonoBehaviour
{
        public GameObject bulletPrefab;
        public GameObject[] gunBulletSpawnPoints;
        private SpriteRenderer gunSprite;
        public float fireRate = 0.3f;

    private void Start() {
        // gunBulletSpawnPoints = transform.Find("BulletSpawnPoint").gameObject;
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
        Instantiate(bulletPrefab, gunBulletSpawnPoints[0].transform.position, gunBulletSpawnPoints[0].transform.rotation);
        Instantiate(bulletPrefab, gunBulletSpawnPoints[1].transform.position, gunBulletSpawnPoints[1].transform.rotation);
        Instantiate(bulletPrefab, gunBulletSpawnPoints[2].transform.position, gunBulletSpawnPoints[2].transform.rotation);
    }
}

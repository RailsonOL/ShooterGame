using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject currentGun;
    public float fireRate = 0.3f;
    [HideInInspector] public int gunOrientation;

    public static WeaponController instance;

    private void Start()
    {
        instance = this;
        SpawnGun();
    }
    void Update()
    {
        Aim();
    }

    void SpawnGun()
    {
        currentGun = Instantiate(currentGun, transform.position, transform.rotation);
        currentGun.transform.parent = transform;
    }

    void Aim()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(currentGun.transform.position);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        currentGun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (mousePos.x < screenPoint.x)
        {
            gunOrientation = -1;
            currentGun.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            gunOrientation = 1;
            currentGun.GetComponent<SpriteRenderer>().flipY = false;
        }
    }

    void FixedUpdate()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
        currentGun.transform.up = direction;
    }

}

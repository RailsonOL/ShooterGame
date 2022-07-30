using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float damage;
    public float knockback;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        rb.velocity = transform.right * speed;
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Enemy") {
            // collision.GetComponent<Enemy>().TakeDamage(damage);
            // collision.GetComponent<Enemy>().Knockback(knockback);
            Destroy(gameObject);
        }
    }
}

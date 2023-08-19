using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Speed of the bullet
    public float speed = 7.0f;

    // Time the bullet will exist
    public float lifeTime = 4.0f; // Add the semicolon here

    private Rigidbody2D rd;
    private Vector3 previousPosition;
    
    void Start()
    {
        previousPosition = transform.position;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;

       if (currentPosition != previousPosition)
        {
             Debug.Log("Bullet is moving.");
        }

        previousPosition = currentPosition;
        transform.Translate(Vector3.up * speed * Time.deltaTime);

    }
    
    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // The player will use this method
    public void Doshoot(Vector2 direction)
    {
        rd.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.lifeTime);
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bounds"))
        {
            Destroy(gameObject);
        }
    }
}

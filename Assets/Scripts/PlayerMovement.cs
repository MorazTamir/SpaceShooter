using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Bullet bulletPrefab;

    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotationSpeed = 5.0f;
     private Rigidbody2D rb;
     private float delatX;
     private float deltaY;
     private Vector2 movement;
     
     public float minX, maxX, minY, maxY; // Define your bounds here

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //move with key pressed
        //bounds
        bounds();
        
        //rotation with mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - rb.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle-90;

         if( Input.GetKeyDown(KeyCode.Space) ){
            Shoot();
        }

    }

    private void FixedUpdate()
    {
        delatX = Input.GetAxis("Horizontal"); 
        deltaY = Input.GetAxis("Vertical");
        movement = new Vector2(delatX, deltaY).normalized * moveSpeed;
        rb.velocity = movement;
    }

    private void bounds()
    {
        if (transform.position.y >= 4.5f)
        {
            transform.position = new Vector3(transform.position.x, 4.5f, 0);
        }
        else if(transform.position.y <= -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, 0);
        }
        
        if (transform.position.x >= 9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
        else if(transform.position.x <= -9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
    }

     private void Shoot()
    {
        if (bulletPrefab != null)
        {
            Bullet bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
            bullet.Doshoot(this.transform.up);
        }
        else
        {
            Debug.LogError("Bullet prefab is not assigned.");
        }
    }


}

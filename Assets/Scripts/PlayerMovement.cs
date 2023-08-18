using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
       
        //rb.velocity = movement;

        //bounds
        bounds();
        // if (transform.position.y >= 2)
        // {
        //     transform.position = new Vector3(transform.position.x, 4.5f, 0);
        // }
        // else if(transform.position.y <= -4.3f)
        // {
        //     transform.position = new Vector3(transform.position.x, -4.5f, 0);
        // }
         // Vector3 newPos = transform.position + new Vector3(movement.x, movement.y, 0) * Time.deltaTime;
         // newPos.x = Mathf.Clamp(newPos.x, Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x,
         //                       Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x);
         // newPos.y = Mathf.Clamp(newPos.y, Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y,
         //                       Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y);
         // transform.position = newPos;

        
        //rotation with mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - rb.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle-90;

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
}

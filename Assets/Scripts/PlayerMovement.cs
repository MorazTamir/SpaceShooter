using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     public float moveSpeed = 1.5f;
     public float rotationSpeed = 5.0f;
     private Rigidbody2D rb;

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
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized * moveSpeed;
        //rb.velocity = movement;

        //bounds
         Vector3 newPos = transform.position + new Vector3(movement.x, movement.y, 0) * Time.deltaTime;
         newPos.x = Mathf.Clamp(newPos.x, Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x,
                               Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x);
         newPos.y = Mathf.Clamp(newPos.y, Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y,
                               Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y);
         transform.position = newPos;

        
        //rotation with mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - rb.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle-90;

    }
    
}

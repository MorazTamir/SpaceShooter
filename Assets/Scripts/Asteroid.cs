using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public float size = 3.0f;
    public GameManager gameManager;

    private Vector2 direction;
    private float spawnSpeed;


    private void Start()
    {
        this.transform.localScale = Vector3.one * this.size * 0.5f;

        _rigidbody = GetComponent<Rigidbody2D>();
        direction = new Vector2(Random.value, Random.value).normalized;
        spawnSpeed = Random.Range(4f - size, 5f - size);
        _rigidbody.AddForce (direction * spawnSpeed, ForceMode2D.Impulse);

       
        if (gameManager != null)
        {
            gameManager.asteroidCount++;
        }
        else
        {
            Debug.LogWarning("GameManager reference not assigned in Asteroid script.");
        }
    }

    void Update()
    {
        
    }
}

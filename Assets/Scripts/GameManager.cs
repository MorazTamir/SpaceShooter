using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;

    public int asteroidCount = 0;
    private int level = 0;

    private void Update()
    {
        if (asteroidCount == 0)
        {
            level++;

            int numAsteroids = 2 + (2 * level);
            for (int i = 0; i < numAsteroids; i++)
            {
                SpawnAsteroid();
            }
        }
    }

    private void SpawnAsteroid()
    {
        float offset = Random.Range(0f, 1f);
        Vector2 viewSpawnPosition = Vector2.zero;

        int edge = Random.Range(0, 4);
        if (edge == 0){
            viewSpawnPosition = new Vector2(offset, 0);
        } else if (edge == 1){
            viewSpawnPosition = new Vector2(offset, 1);
        } else if (edge == 2){
            viewSpawnPosition = new Vector2(0, offset);
        } else if (edge == 3){
            viewSpawnPosition = new Vector2(1, offset);
        }
        Vector2 worldSpawnPosition = Camera.main.ViewportToWorldPoint(viewSpawnPosition);
        Asteroid asteroid = Instantiate(asteroidPrefab, worldSpawnPosition, Quaternion.identity).GetComponent<Asteroid>();
        asteroid.gameManager = this;
    }
}



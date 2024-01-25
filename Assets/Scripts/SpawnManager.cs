using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20.0f;
    private float spawnPosZ = 60.0f;

    private float startDelay = 2.0f;
    private float spawnInterval = 2.0f;

    public static bool isGameOver = false;
    public Canvas gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        // Repeatedly spawn animals at a random location
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        // Hide the game over canvas
        gameOverCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) {
            // Stop spawning animals
            CancelInvoke("SpawnRandomAnimal");
            // Show the game over canvas
            gameOverCanvas.gameObject.SetActive(true);
        }
    }

    void SpawnRandomAnimal() {
        // Random animal spawn
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        // Random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        // Instantiate animal at random spawn location
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}

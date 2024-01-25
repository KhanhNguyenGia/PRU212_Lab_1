using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float maxRange = 10.0f;

    public static float score = 0.0f;

    public GameObject projectilePrefab;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Limit player movement to the left and right bounds
        if (transform.position.x < -maxRange) {
            transform.position = new Vector3(-maxRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > maxRange) {
            transform.position = new Vector3(maxRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal"); // -1 to 1
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space)) {
            // Launch a projectile from the player
            var vector3 = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
            Instantiate(projectilePrefab, vector3, projectilePrefab.transform.rotation);
        }

        scoreText.text = score.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float spawnCooldown = 2.0f; // Cooldown time in seconds
    private float lastSpawnTime;
    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSpawnTime > spawnCooldown)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                lastSpawnTime = Time.time; // Update the last spawn time
            }
        }
        // On spacebar press, send dog
       
    }
}

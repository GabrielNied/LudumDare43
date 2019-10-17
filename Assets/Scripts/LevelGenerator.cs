using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public GameObject[] chunks;
    public float movingSpeed;

    private float timeSinceStart;

    // Update is called once per frame
    void Update() {

        // Checks if it needs to spawn or destroy stuff.
        foreach (GameObject chunkSpawner in GameObject.FindGameObjectsWithTag("ChunkSpawner"))
        {
            if (Camera.main.WorldToViewportPoint(chunkSpawner.transform.position).y <= 1.2)
            {
                Instantiate(
                    chunks[Random.Range(0, chunks.Length)],
                    chunkSpawner.transform.position,
                    Quaternion.identity,
                    this.transform
                    );

                Destroy(chunkSpawner);
            }
        }

        foreach (GameObject chunkEnd in GameObject.FindGameObjectsWithTag("ChunkEnd"))
        {
            if (Camera.main.WorldToViewportPoint(chunkEnd.transform.position).y <= -0.1)
                Destroy(chunkEnd.transform.parent.gameObject);
        }

        timeSinceStart = Time.timeSinceLevelLoad * 0.000002f;
        movingSpeed += timeSinceStart;

        // Keeps moving down.
        this.transform.Translate(Vector3.down * movingSpeed * Time.deltaTime);
	}
}

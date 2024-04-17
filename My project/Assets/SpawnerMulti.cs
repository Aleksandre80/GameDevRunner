using System.Collections;
using UnityEngine;

public class SpawnerMulti : MonoBehaviour
{
    public GameObject cubePrefab;
    public Vector3[] spawnPoints;
    public float spawnDelay = 2f;
    public float cubeSpeed = 5f;
    public GameObject player;
    public float playerSpeed = 10f;

    private float timeSinceLastSpawn;
    private const float distanceAhead = 30f; // Distance constante devant le joueur pour le spawn

    void Start()
    {
        timeSinceLastSpawn = spawnDelay;
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnDelay)
        {
            SpawnCube();
            timeSinceLastSpawn = 0;
        }

        // Ce bloc reste inchangé car il gère localement le mouvement des cubes pour tous les joueurs
        foreach (Transform child in transform)
        {
            child.Translate(-Vector3.right * cubeSpeed * Time.deltaTime, Space.World);
        }

        CheckAndDestroyCubesBehindPlayer();
    }

    void SpawnCube()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);

        // Calcule le nouveau point de spawn en utilisant la position actuelle du joueur
        Vector3 spawnPoint = new Vector3(player.transform.position.x + distanceAhead, spawnPoints[spawnIndex].y, spawnPoints[spawnIndex].z);

        Instantiate(cubePrefab, spawnPoint, Quaternion.Euler(0, -90, 0));
    }

    void CheckAndDestroyCubesBehindPlayer()
    {
        foreach (Transform child in transform)
        {
            if (child.position.x < player.transform.position.x - 10)
            {
                Destroy(child.gameObject);
            }
        }
    }
}

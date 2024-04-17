using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject cubePrefab; // Le prefab du cube à instancier.
    public Vector3[] spawnPoints; // Les points où les cubes peuvent apparaître.
    public float spawnDelay = 2f; // Délai entre chaque spawn.
    public float cubeSpeed = 5f; // Vitesse à laquelle les cubes reculent.
    public GameObject player; // Référence au joueur.
    public float playerSpeed = 10f; // Vitesse de déplacement du joueur.

    private float timeSinceLastSpawn; // Temps écoulé depuis le dernier spawn.

    void Start()
    {
        timeSinceLastSpawn = spawnDelay;
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        // Déplacer les points de spawn en fonction du mouvement du joueur.
        MoveSpawnPointsWithPlayer();

        if (timeSinceLastSpawn >= spawnDelay)
        {
            SpawnCube();
            timeSinceLastSpawn = 0;
        }

        // Déplacer tous les cubes enfants vers l'arrière.
        foreach (Transform child in transform)
        {
            child.Translate(-Vector3.right * cubeSpeed * Time.deltaTime, Space.World);
        }

        // Vérifier et supprimer les cubes derrière le joueur.
        CheckAndDestroyCubesBehindPlayer();
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

    void SpawnCube()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPoint = spawnPoints[spawnIndex] + transform.position;

        Instantiate(cubePrefab, spawnPoint, Quaternion.Euler(0, -90, 0), transform);

    }

    void MoveSpawnPointsWithPlayer()
    {
        Vector3 playerMovement = Vector3.right * playerSpeed * Time.deltaTime;

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i] += playerMovement;
        }

        transform.position += playerMovement;
    }
}

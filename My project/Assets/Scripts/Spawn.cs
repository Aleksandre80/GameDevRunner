using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject cubePrefab; // Le prefab du cube � instancier.
    public Vector3[] spawnPoints; // Les points o� les cubes peuvent appara�tre.
    public float spawnDelay = 2f; // D�lai entre chaque spawn.
    public float cubeSpeed = 5f; // Vitesse � laquelle les cubes reculent.
    public GameObject player; // R�f�rence au joueur.
    public float playerSpeed = 10f; // Vitesse de d�placement du joueur.

    private float timeSinceLastSpawn; // Temps �coul� depuis le dernier spawn.

    void Start()
    {
        timeSinceLastSpawn = spawnDelay;
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        // D�placer les points de spawn en fonction du mouvement du joueur.
        MoveSpawnPointsWithPlayer();

        if (timeSinceLastSpawn >= spawnDelay)
        {
            SpawnCube();
            timeSinceLastSpawn = 0;
        }

        // D�placer tous les cubes enfants vers l'arri�re.
        foreach (Transform child in transform)
        {
            child.Translate(-Vector3.right * cubeSpeed * Time.deltaTime, Space.World);
        }

        // V�rifier et supprimer les cubes derri�re le joueur.
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

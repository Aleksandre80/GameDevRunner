using UnityEngine;
using Photon.Pun;

public class Spawner : MonoBehaviourPun
{
    public GameObject collectiblePrefab;
    public BoxCollider2D spawnArea;
    public float minSpeed = 4.0f;
    public float maxSpeed = 8.0f;

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // Seul le MasterClient va générer les objets pour éviter les duplications
            // Synchroniser la graine sur tous les clients
            int seed = GenerateSeed();
            photonView.RPC("SynchronizeSeed", RpcTarget.All, seed);

            InvokeRepeating("SpawnObject", 2f, 2f); // Attendre 2 secondes avant de commencer pour s'assurer que la graine est synchronisée
        }
    }

    [PunRPC]
    void SynchronizeSeed(int seed)
    {
        Random.InitState(seed);
    }

    void SpawnObject()
    {
        float minX = spawnArea.bounds.min.x;
        float maxX = spawnArea.bounds.max.x;

        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        // Instancier l'objet sur le réseau
        GameObject collectible = PhotonNetwork.Instantiate(collectiblePrefab.name, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = collectible.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, -randomSpeed);
    }

    private int GenerateSeed()
    {
        // Utiliser une graine basée sur le temps pour la première génération
        return (int)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
    }
}

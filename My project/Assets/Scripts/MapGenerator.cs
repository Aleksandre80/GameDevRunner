using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject mapSegmentPrefab; // Votre prefab de segment de map.
    public GameObject player; // Le joueur.
    public float initialSpawnX = 20f; // Position X initiale pour le premier segment.
    public float segmentLength = 30; // La longueur d'un segment de map.
    public int numberOfSegmentsAhead = 5; // Nombre de segments à garder devant le joueur.
    private float safeZone = -10f; // Distance de sécurité pour ne pas supprimer le segment actuellement parcouru par le joueur.

    private List<GameObject> activeSegments; // Liste pour garder une trace des segments actifs.
    private float lastSpawnX; // Dernière position X à laquelle un segment a été généré.

    void Start()
    {
        activeSegments = new List<GameObject>();
        lastSpawnX = initialSpawnX - segmentLength; // S'assurer que le premier segment est généré à la position initiale.

        // Générer les premiers segments.
        for (int i = 0; i < numberOfSegmentsAhead; i++)
        {
            SpawnMapSegment();
        }
    }

    void Update()
    {
        // Vérifier si nous devons générer un nouveau segment.
        if (player.transform.position.x + safeZone > lastSpawnX - (numberOfSegmentsAhead - 1) * segmentLength)
        {
            SpawnMapSegment();
            DeletePassedSegment();
        }
    }

    private void SpawnMapSegment()
    {
        // Calculer la position du nouveau segment pour qu'il suive immédiatement le dernier.
        float newSpawnX = lastSpawnX + segmentLength;
        GameObject segment = Instantiate(mapSegmentPrefab, new Vector3(newSpawnX, 0, 0), Quaternion.identity);
        activeSegments.Add(segment);
        lastSpawnX = newSpawnX; // Mettre à jour la dernière position X de spawn.
    }

    private void DeletePassedSegment()
    {
        // Supprimer le segment de map le plus ancien si nécessaire.
        if (activeSegments.Count > numberOfSegmentsAhead)
        {
            GameObject segmentToDelete = activeSegments[0];
            activeSegments.RemoveAt(0);
            Destroy(segmentToDelete);
        }
    }
}

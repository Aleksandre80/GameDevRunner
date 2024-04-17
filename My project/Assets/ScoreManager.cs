using UnityEngine;
using TMPro; // Assure-toi d'inclure l'espace de noms pour TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // L'UI TextMeshPro où afficher le score
    public Transform playerTransform; // La référence à la position du joueur
    private float score;

    void Start()
    {
        score = 0;
        UpdateScoreUI();
    }

    void Update()
    {
        // Convertis la position x du joueur en score en le divisant par un facteur pour simplifier le nombre
        score = Mathf.Floor(playerTransform.position.x / 10); // Divise par 10 et arrondis à l'entier inférieur
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString("0"); // Affiche le score sans les virgules
    }
}

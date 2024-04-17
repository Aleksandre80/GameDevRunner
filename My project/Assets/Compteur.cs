using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Compteur : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreTXT;
    public GameObject collectibleBase;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            score++;
            scoreTXT.text = "Score: " + score;

            other.gameObject.SetActive(false);
        }
    }
}

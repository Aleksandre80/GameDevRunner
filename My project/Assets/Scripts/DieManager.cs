using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieManager : MonoBehaviour
{
    public collision col;
    public GameObject dieFrame;
    public AudioSource audioSource;
    void Start()
    {
        dieFrame.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (col.isDie)
        {
            Time.timeScale = 0;
            dieFrame.SetActive(true);
            audioSource.Stop();
        }
    }

    public void RetryGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

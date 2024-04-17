using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{

    public Renderer cube;

    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            cube.material.SetColor("_Color", Color.red);
            Debug.Log("collision");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            cube.material.SetColor("_Color", Color.white);
            Debug.Log("collision");
        }
    }
}

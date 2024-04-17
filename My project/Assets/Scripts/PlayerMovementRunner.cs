using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerMovementRunner : MonoBehaviourPunCallbacks
{
    public float speed;
    public Transform right;
    public Transform left;
    public int move;
    public Rigidbody rb;
    public int jumpForce;
    public bool jump;

    void Start()
    {
        jump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            ProcessInput();
        }
        else
        {
            GetComponentInChildren<Camera>().gameObject.SetActive(false);
        }
    }

    public void ProcessInput()
    {
        transform.Translate(new Vector3(1, 0) * speed * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.RightArrow) && move < 1)
        {
            transform.position = right.transform.position;
            move++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && move > -1)
        {
            transform.position = left.transform.position;
            move--;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if (jump)
        {
            Debug.Log("jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 8;
    private bool isSpeedBoosted = false;
    private float boostCooldownTimer = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (!isSpeedBoosted)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)) 
            {
                StartCoroutine(BoostSpeed());
            }
        }

        if (isSpeedBoosted)
        {
            boostCooldownTimer += Time.deltaTime;
            if (boostCooldownTimer >= 10f) // Cooldown de 10 secondes pour réactiver le boost
            {
                boostCooldownTimer = 0f;
                isSpeedBoosted = false;
            }
        }
    }

    private IEnumerator BoostSpeed()
    {
        isSpeedBoosted = true;
        Debug.Log("Vitesse boostée pendant 3 secondes...");
        speed = 12;

        yield return new WaitForSeconds(3f);

        Debug.Log("Fin du boost de vitesse.");
        speed = 8;
    }
}

using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(-Vector3.right * speed * Time.deltaTime, Space.World);
    }

    // Vous pouvez �galement inclure la logique de destruction ici, si vous le souhaitez.
    void CheckAndDestroy()
    {
        // Exemple : D�truire le cube s'il d�passe une certaine limite.
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}

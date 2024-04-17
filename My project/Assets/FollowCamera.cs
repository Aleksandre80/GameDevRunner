using UnityEngine;
using Photon.Pun;

public class FollowCamera : MonoBehaviour
{
    public Vector3 offset; // Le d�calage de la cam�ra par rapport au joueur
    private Transform playerTransform;

    void Update()
    {
        // Trouvez le joueur local uniquement si nous n'avons pas d�j� une r�f�rence
        if (playerTransform == null)
        {
            GameObject localPlayer = FindLocalPlayer();
            if (localPlayer != null)
            {
                playerTransform = localPlayer.transform;
            }
        }

        if (playerTransform != null)
        {
            // Mettez � jour la position de la cam�ra avec le d�calage
            transform.position = playerTransform.position + offset;
        }
    }

    private GameObject FindLocalPlayer()
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (player.GetComponent<PhotonView>().IsMine)
            {
                return player;
            }
        }
        return null;
    }
}

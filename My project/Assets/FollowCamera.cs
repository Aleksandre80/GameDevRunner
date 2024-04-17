using UnityEngine;
using Photon.Pun;

public class FollowCamera : MonoBehaviour
{
    public Vector3 offset; // Le décalage de la caméra par rapport au joueur
    private Transform playerTransform;

    void Update()
    {
        // Trouvez le joueur local uniquement si nous n'avons pas déjà une référence
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
            // Mettez à jour la position de la caméra avec le décalage
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

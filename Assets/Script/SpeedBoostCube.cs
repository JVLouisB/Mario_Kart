using UnityEngine;

public class SpeedBoostCube : MonoBehaviour
{
    public float speedMultiplier = 2f;  // Multiplie la vitesse du joueur par 2
    public float boostDuration = 3f;     // Dur�e du boost en secondes

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // V�rifie si l'objet en collision est le joueur
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                // Applique le boost de vitesse pendant la dur�e sp�cifi�e
                playerMovement.StartCoroutine(playerMovement.SpeedBoost(speedMultiplier, boostDuration));
            }

            // D�truire le cube apr�s la collision (facultatif)
            Destroy(gameObject);
        }


    }
}

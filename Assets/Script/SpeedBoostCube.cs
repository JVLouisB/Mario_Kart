using UnityEngine;

public class SpeedBoostCube : MonoBehaviour
{
    public float speedMultiplier = 2f;  // Multiplie la vitesse du joueur par 2
    public float boostDuration = 3f;     // Durée du boost en secondes

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie si l'objet en collision est le joueur
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                // Applique le boost de vitesse pendant la durée spécifiée
                playerMovement.StartCoroutine(playerMovement.SpeedBoost(speedMultiplier, boostDuration));
            }

            // Détruire le cube après la collision (facultatif)
            Destroy(gameObject);
        }


    }
}

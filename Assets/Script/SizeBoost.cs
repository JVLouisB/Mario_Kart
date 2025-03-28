using UnityEngine;

public class SizeBoost : MonoBehaviour
{
    public float sizeMultiplier = 2f; // Facteur de grossissement
    public float speedBoostAmount = 5f; // Augmentation de la vitesse
    public float boostDuration = 4f; // Durée du boost en secondes

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie si c'est le joueur
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                // Active le boost de taille et de vitesse du joueur
                playerMovement.StartCoroutine(playerMovement.SizeAndSpeedBoost(sizeMultiplier, speedBoostAmount, boostDuration));
            }


            // Détruit l'objet déclencheur après la collision
            Destroy(gameObject);
        }

        if (other.CompareTag("Player")) // Vérifie si c'est le joueur
        {
            PlayerMovement2 playerMovement2 = other.GetComponent<PlayerMovement2>();

            if (playerMovement2 != null)
            {
                // Active le boost de taille et de vitesse du joueur
                playerMovement2.StartCoroutine(playerMovement2.SizeAndSpeedBoost(sizeMultiplier, speedBoostAmount, boostDuration));
            }


            // Détruit l'objet déclencheur après la collision
            Destroy(gameObject);
        }
    }


}

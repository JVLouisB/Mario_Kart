using UnityEngine;

public class Boost : MonoBehaviour
{
    public float speedBoostAmount = 5f;  // Augmentation de vitesse
    public float boostDuration = 3f;     // Durée du boost

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie si c'est le joueur
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                // Applique le boost de vitesse du joueur
                playerMovement.StartCoroutine(playerMovement.SpeedBoost(speedBoostAmount, boostDuration));
            }

            // Détruire l'objet après la collision pour ne pas interférer avec les futurs boosts
            Destroy(gameObject);
        }
    }
}

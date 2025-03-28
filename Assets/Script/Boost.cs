using UnityEngine;

public class Boost : MonoBehaviour
{
    public float speedBoostAmount = 5f;  // Augmentation de vitesse
    public float boostDuration = 3f;     // Dur�e du boost

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // V�rifie si c'est le joueur
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                // Applique le boost de vitesse du joueur
                playerMovement.StartCoroutine(playerMovement.SpeedBoost(speedBoostAmount, boostDuration));
            }

            // D�truire l'objet apr�s la collision pour ne pas interf�rer avec les futurs boosts
            Destroy(gameObject);
        }
    }
}

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;  // Vitesse de base
    private float currentSpeed;
    private Rigidbody rb;
    public float rotationSpeed = 700f;
    public float driftMultiplier = 1.5f;
    private bool isDrifting = false;

    private float _speedboost;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = speed;
    }

    private void Update()
    {
        MovePlayer();
        Debug.Log(currentSpeed);
        //Debug.Log(speed);
    }

    private void MovePlayer()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.A)) horizontal = -1f;
        if (Input.GetKey(KeyCode.D)) horizontal = 1f;
        if (Input.GetKey(KeyCode.W)) vertical = 1f;
        if (Input.GetKey(KeyCode.S)) vertical = -1f;

        bool isBoostingTurn = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float currentRotationSpeed = isBoostingTurn ? rotationSpeed * 2 : rotationSpeed;

        // Vérifier si le joueur drift
        if (Input.GetKey(KeyCode.Space))
        {
            isDrifting = true;
            currentSpeed = speed * driftMultiplier;
        }
        else
        {
            isDrifting = false;
            currentSpeed = speed;
        }

        // Déplacer le joueur avec la vitesse actuelle (y compris le boost et le drift)
        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized * currentSpeed * (1+_speedboost) * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            if (isDrifting)
            {
                // Appliquer une légère dérive en drift
                targetRotation *= Quaternion.Euler(0, horizontal * 15f, 0);
            }

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, currentRotationSpeed * Time.deltaTime);
        }
    }

    public IEnumerator SpeedBoost(float speedMultiplier, float duration)
    {
        // Multiplier la vitesse actuelle
        _speedboost = speed * speedMultiplier;

        // Attendre la durée du boost
        yield return new WaitForSeconds(duration);

        // Réinitialiser la vitesse à la normale après la durée du boost
        _speedboost = 0 ;
    }

    public IEnumerator SizeAndSpeedBoost(float sizeMultiplier, float speedIncrease, float duration)
    {
        // Augmente la taille du joueur
        transform.localScale *= sizeMultiplier;

        // Augmente la vitesse
        currentSpeed += speedIncrease;

        // Attend la durée du boost
        yield return new WaitForSeconds(duration);

        // Remet la taille normale
        transform.localScale /= sizeMultiplier;

        // Réduit la vitesse
        currentSpeed -= speedIncrease;
    }


}


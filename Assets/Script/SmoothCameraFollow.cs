using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 6f; // Distance derrière le kart
    public float height = 3f;   // Hauteur de la caméra
    public float rotationDamping = 3f; // Lissage de la rotation

    void LateUpdate()
    {
        if (target == null) return;

        // Position cible
        Vector3 wantedPosition = target.position - target.forward * distance + Vector3.up * height;
        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * rotationDamping);

        // Rotation vers le kart
        Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
    }
}

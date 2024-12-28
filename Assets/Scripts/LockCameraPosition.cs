using UnityEngine;

public class LockCameraPosition : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        // Record the initial position and rotation of the camera
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // Lock the camera's position and rotation
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}

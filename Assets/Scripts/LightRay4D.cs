using UnityEngine;

public class LightRay4D : MonoBehaviour
{
    public Vector4 position4D; // 4D position of the light ray
    public Vector4 direction4D; // Direction vector in 4D space
    public float speed = 5f; // Speed of the light ray
    public float sphereMinus1Radius;
    public float innerSpaceRadius;
    public float spherePlus1Radius;

    private Vector4 center4D = Vector4.zero; // Center for all spheres

    void Start()
    {
        // Initialize position and direction
        position4D = center4D;
        direction4D = new Vector4(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized;
    }

    void Update()
    {
        MoveRay();
        HandleSphereInteractions();
    }

    void MoveRay()
    {
        // Update position in 4D space
        position4D += direction4D * speed * Time.deltaTime;

        // Project the 4D position into 3D space
        Vector3 projectedPosition = ProjectTo3D(position4D);
        transform.position = projectedPosition;
    }

    void HandleSphereInteractions()
    {
        float distanceToCenter = Vector4.Distance(position4D, center4D);

        if (distanceToCenter < sphereMinus1Radius)
        {
            ReflectAtBoundary(sphereMinus1Radius);
        }
        else if (distanceToCenter < innerSpaceRadius)
        {
            ReflectAtBoundary(innerSpaceRadius);
        }
        else if (distanceToCenter < spherePlus1Radius)
        {
            ReflectAtBoundary(spherePlus1Radius);
        }
        else
        {
            // Prevent escaping SpherePlus1
            direction4D = -direction4D.normalized;
        }
    }

    void ReflectAtBoundary(float sphereRadius)
    {
        // Calculate the normal at the collision point
        Vector4 normal = (position4D - center4D).normalized;

        // Reflect the direction vector
        direction4D = direction4D - 2 * Vector4.Dot(direction4D, normal) * normal;
        direction4D = direction4D.normalized;
    }

    Vector3 ProjectTo3D(Vector4 pos4D)
    {
        // Avoid division by zero
        float w = Mathf.Approximately(pos4D.w, 0f) ? 0.0001f : pos4D.w;

        // Perspective projection into 3D
        return new Vector3(pos4D.x / w, pos4D.y / w, pos4D.z / w);
    }
}

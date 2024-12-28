using UnityEngine;

public class LightSystemController : MonoBehaviour
{
    public GameObject lightRayPrefab; // Prefab for the light ray
    public GameObject sphereMinus1Object;
    public GameObject innerSpaceObject;
    public GameObject spherePlus1Object;

    private float sphereMinus1Radius;
    private float innerSpaceRadius;
    private float spherePlus1Radius;

    void Start()
    {
        // Calculate sphere radii based on their scales
        sphereMinus1Radius = sphereMinus1Object.transform.localScale.x / 2f;
        innerSpaceRadius = innerSpaceObject.transform.localScale.x / 2f;
        spherePlus1Radius = spherePlus1Object.transform.localScale.x / 2f;

        // Spawn the initial light ray
        SpawnLightRay();
    }

    void SpawnLightRay()
    {
        GameObject ray = Instantiate(lightRayPrefab, Vector3.zero, Quaternion.identity);
        LightRay4D rayScript = ray.GetComponent<LightRay4D>();

        if (rayScript != null)
        {
            // Pass sphere radii to the light ray
            rayScript.sphereMinus1Radius = sphereMinus1Radius;
            rayScript.innerSpaceRadius = innerSpaceRadius;
            rayScript.spherePlus1Radius = spherePlus1Radius;
        }
    }
}

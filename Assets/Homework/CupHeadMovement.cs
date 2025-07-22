using UnityEngine;

public class CupHeadMovement : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 360f;
    [SerializeField] float radiusSpeed = 1;
    [SerializeField] float minRadius = 2f;
    [SerializeField] float maxRadius = 5f;
    [SerializeField] AnimationCurve distanceOverTime;

    float baseRotationDeg;
    float virtualTime;

    void Update()
    {
        const float Pi2 = 2 * Mathf.PI;
        baseRotationDeg += rotationSpeed * Time.deltaTime;
        float baseRotationRad = baseRotationDeg * Mathf.Deg2Rad;

        /*
        virtualTime += Time.deltaTime * Pi2 * frequency;
        float radiusT = (Mathf.Sin(virtualTime) + 1) * 0.5f;
        */
        virtualTime += Time.deltaTime * radiusSpeed;
        float radiusT = distanceOverTime.Evaluate(virtualTime);
        float radius = Mathf.Lerp(minRadius, maxRadius, radiusT);

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            float t = (float)i / transform.childCount;
            float angleRad = baseRotationRad + t * Pi2;

            child.localPosition = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad)) * radius;
        }
    }
}

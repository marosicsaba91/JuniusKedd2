using System;
using UnityEngine;

public class ChildRotator : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 360;
    [SerializeField] float minDistance = 2;
    [SerializeField] float maxDistance = 3;
    [SerializeField] float distanceFrequency = 1;

    float baseAngleDeg = 0;
    float distancePhaseRad = 0;

    void Update()
    {
        Vector3 center = transform.position;

        baseAngleDeg += Time.deltaTime * rotationSpeed;
        distancePhaseRad += Time.deltaTime * 2 * Mathf.PI * distanceFrequency;

        float distance01 = (Mathf.Sin(distancePhaseRad) + 1) / 2;
        float distance = Mathf.Lerp(minDistance, maxDistance, distance01);

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            float phase01 = (float)i / transform.childCount;
            float angleDeg = baseAngleDeg + (phase01 * 360);

            float angleRad = angleDeg * Mathf.Deg2Rad;
            Vector3 direction = new(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
            child.position = center + (direction * distance);
        }
    }
}

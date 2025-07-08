using System;
using UnityEngine;

public class ScreenTeleporter : MonoBehaviour
{
    Collider2D myCollider2D;
    Camera mainCamera;

    void Awake()
    {
        myCollider2D = GetComponent<Collider2D>();
        mainCamera = FindAnyObjectByType<Camera>();
    }

    void FixedUpdate()
    {
        Rect cameraRect = mainCamera.GetRect();
        Rect objectRect = myCollider2D.GetRect();
        Vector2 p = transform.position;

        if (cameraRect.Contains(p))
            return;

        if (cameraRect.xMax < objectRect.xMin) // Jobbra kilóg
            transform.position += Vector3.left * (cameraRect.width + objectRect.width);
        else if (cameraRect.xMin > objectRect.xMax) //Balra lóg ki
            transform.position += Vector3.right * (cameraRect.width + objectRect.width);

        if (cameraRect.yMax < objectRect.yMin) // Fent kilóg
            transform.position += Vector3.down * (cameraRect.height + objectRect.height);
        else if (cameraRect.yMin > objectRect.yMax) //Lent lóg ki
            transform.position += Vector3.up * (cameraRect.height + objectRect.height);

    }

    void OnDrawGizmos()
    {
        if (mainCamera == null || myCollider2D == null)
            return;

        Gizmos.color = Color.cyan;
        Rect cameraRect = mainCamera.GetRect();
        Gizmos.DrawWireCube(cameraRect.center, cameraRect.size);
        Rect objectRect = myCollider2D.GetRect();
        Gizmos.DrawWireCube(objectRect.center, objectRect.size);
    }
}

using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseScreenPoint = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mouseScreenPoint);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log($"HIT:  {hit.collider.name}    {hit.point}");
            }
        }
    }
}

using UnityEngine;

class ScreenSpacePractice : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float cameraDistance;

    void Update()
    {
        //Vector3 wp = Vector3.zero;
        //Vector3 screenPoint = cam.WorldToScreenPoint(wp); // Z = tácolság

        //Vector3 mousePoint = Input.mousePosition;  // Screen Space
        //mousePoint.z = cameraDistance;  // Távolság a kamerától
        //transform.position = cam.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDown()
    {

    }
}
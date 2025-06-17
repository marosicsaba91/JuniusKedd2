using UnityEngine;

class MyFirstScript : MonoBehaviour
{
    void Start()
    {
        Vector2 v2a = new(2, 3);
        Vector3 v3a = new(3, 4, 6);

        Vector3 v3b = Vector3.zero;
        Vector3 v3c = Vector3.one;

        Vector3 v3d = Vector3.up;    // (0,1,0)
        Vector3 v3e = Vector3.left;  // (-1,0,0)
        Vector3 v3f = Vector3.back;  // (0,0,-1)

        // ------------------

        Vector3 v3g = v3f + v3c;
        v3g += new Vector3(1, 2, 3);

        Vector3 v3h = v3f * 3f;
        float l = v3f.magnitude;

        Vector3 v3i = v3f.normalized;
        v3f.Normalize();
    }

}
using UnityEngine;

public class SinusMover : MonoBehaviour
{
    [SerializeField] float distance = 1;
    [SerializeField] float frequency = 1; 

    void Update()
    {
        float z = distance * Mathf.Sin(Time.time * frequency);
        transform.localPosition = new Vector3(0,0, z);
    }

}

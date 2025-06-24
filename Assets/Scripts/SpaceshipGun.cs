using UnityEngine;
using UnityEngine.Serialization;

public class SpaceshipGun : MonoBehaviour
{
    [SerializeField, FormerlySerializedAs("projectileProto")] GameObject projectilePrototype;
    [SerializeField] KeyCode shootKey = KeyCode.Space;

    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            Instantiate(projectilePrototype, transform.position, transform.rotation);
        }        
    }
}

using UnityEngine;

enum ShootingType
{
    Loop,
    SameTime,
    PinPong
}

public class SpaceshipGunController : MonoBehaviour
{
    [SerializeField] SpaceshipGun[] guns;
    [SerializeField] KeyCode shootKey = KeyCode.Space;
    [SerializeField] ShootingType shootingType;

    int count = 0;
    int direction = 1;
    int pingPongIndex = 0;

    void OnValidate()
    {
        if (guns == null || guns.Length == 0)
            guns = GetComponentsInChildren<SpaceshipGun>(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(shootKey))
            Shoot();
    }

    void Shoot()
    {
        if (shootingType == ShootingType.Loop)
        {
            guns[count % guns.Length].Shoot();
        }
        else if (shootingType == ShootingType.SameTime)
        {
            foreach (SpaceshipGun gun in guns)
                gun.Shoot();
        }
        else if (shootingType == ShootingType.PinPong)
        {
            guns[pingPongIndex].Shoot();

            if (guns.Length > 1)
            {
                if (direction > 0 && pingPongIndex == guns.Length - 1)
                    direction = -1;
                else if (direction < 0 && pingPongIndex == 0)
                    direction = 1;

                pingPongIndex += direction;
            }
        }

        count++;
    }
}

using UnityEngine;

enum ShootingType
{
    Loop,
    SameTime,
    PinPong
}

public class SpaceshipGunController : MonoBehaviour
{
    [SerializeField] GameObject[] projectilePrototypes;
    [SerializeField] Transform minGunPoint;                // Házi:  Nem transformokkal
    [SerializeField] Transform maxGunPoint;
    [SerializeField, Min(1)] int gunCount = 1;
    [SerializeField] KeyCode shootKey = KeyCode.Space;
    [SerializeField] ShootingType shootingType;
    [SerializeField] SpriteRenderer bullsEye;
    [SerializeField] LayerMask rayCastMask;
    [SerializeField] AudioSource gunSound;
    [SerializeField] AudioClip[] gunSoundClips;
    [SerializeField] ParticleSystem gunMazzlePartiles;

    int projectileIndex = 0;
    int direction = 1;
    int pingPongIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(shootKey))
            Shoot();

        Aim();
    }

    void Aim()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            transform.up,
            float.PositiveInfinity,
            rayCastMask);

        bool isHit = hit.collider != null;

        bullsEye.enabled = isHit;
        if (isHit)
        {
            bullsEye.transform.position = hit.point;
        }
    }

    void Shoot()
    {
        if (shootingType == ShootingType.Loop)
        {
            Pose gunPoint = GetPose(projectileIndex % gunCount);
            Shoot(gunPoint.position, gunPoint.rotation);
        }
        else if (shootingType == ShootingType.SameTime)
        {
            for (int i = 0; i < gunCount; i++)
            {
                Pose gunPoint = GetPose(i);
                Shoot(gunPoint.position, gunPoint.rotation);
            }
        }
        else if (shootingType == ShootingType.PinPong)
        {
            Pose gunPoint = GetPose(pingPongIndex);
            Shoot(gunPoint.position, gunPoint.rotation);

            if (gunCount > 1)
            {
                if (direction > 0 && pingPongIndex == gunCount - 1)
                    direction = -1;
                else if (direction < 0 && pingPongIndex == 0)
                    direction = 1;

                pingPongIndex += direction;
            }
        }

        projectileIndex++;
    }

    Pose GetPose(int index)
    {
        float t = (float)index / (gunCount - 1);

        return new()
        {
            position = Vector3.Lerp(minGunPoint.position, maxGunPoint.position, t),
            rotation = Quaternion.Slerp(minGunPoint.rotation, maxGunPoint.rotation, t)
        };
    }

    void Shoot(Vector3 position, Quaternion rotation)
    {
        int randomIndex = Random.Range(0, projectilePrototypes.Length);
        GameObject p = projectilePrototypes[randomIndex];
        GameObject newProjectile = Instantiate(p, position, rotation);

        gunSound.clip = gunSoundClips[projectileIndex % gunSoundClips.Length];
        gunSound.Play();

        gunMazzlePartiles.Play();
    }

    [SerializeField] float gismoRad;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        for (int i = 0; i < gunCount; i++)
        {
            Pose p = GetPose(i);
            GizmoExtras.DrawCircle(p.position, gismoRad);

            Vector3 offset = p.rotation * Vector3.up;
            Gizmos.DrawLine(p.position, p.position + offset);
        }
    }
}

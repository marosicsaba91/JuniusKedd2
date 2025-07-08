using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] List<Asteroid> asteroids;
    [SerializeField] int startCount = 5;
    [SerializeField] float minDistanceFromCameraCentre;

    [SerializeField] bool useRandomSeed;
    [SerializeField] int seed;

    void Start()
    {
        Camera cam = Camera.main;
        Rect rect = cam.GetRect();

        System.Random random = useRandomSeed ? new() : new(seed);

        for (int i = 0; i < startCount; i++)
        {
            int randomIndex = random.Next(asteroids.Count - 1);
            Asteroid a = asteroids[randomIndex];

            Vector3 p;
            do
            {
                p = rect.GetRandomPoint(random);
            } while (Vector2.Distance(p,rect.center) < minDistanceFromCameraCentre);
                       
            Quaternion r = Quaternion.Euler(0, 0, (float)(random.NextDouble() * 360));
            Instantiate(a, p, r, transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Camera.main.GetRect().center, minDistanceFromCameraCentre);
    }
}

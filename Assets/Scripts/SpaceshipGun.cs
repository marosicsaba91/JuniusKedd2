using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class SpaceshipGun : MonoBehaviour
{
    [SerializeField] GameObject[] projectilePrototypes;

    int count;

    public void Shoot()
    {
        int randomIndex = Random.Range(0, projectilePrototypes.Length);
        GameObject p = projectilePrototypes[randomIndex];

        //GameObject p = projectilePrototypes[count % projectilePrototypes.Length;

        GameObject newProjectile = Instantiate(p, transform.position, transform.rotation);
        count++;
    }
}

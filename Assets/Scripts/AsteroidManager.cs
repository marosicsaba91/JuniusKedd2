using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] List<Asteroid> asteroids;
    [SerializeField] int startCount = 5;
    [SerializeField] float minDistanceFromCameraCentre;

    [SerializeField] bool useRandomSeed;
    [SerializeField] int seed;

    [SerializeField] TMP_Text asteroidCountText;

    List<Asteroid> livingAsteroids = new();
    public void AddNewAsteroid(Asteroid a)
    {
        livingAsteroids.Add(a);
        OnAsteroidCountChanged();
    }

    public void RemoveAsteroid(Asteroid a)
    {
        livingAsteroids.Remove(a);
        OnAsteroidCountChanged();
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        Camera cam = Camera.main;
        Rect rect = cam.GetRect();

        System.Random random = useRandomSeed ? new() : new(seed);

        for (int i = 0; i < startCount; i++)
        {
            int randomIndex = random.Next(asteroids.Count - 1);
            Asteroid asteroidPrefab = asteroids[randomIndex];

            Vector3 p;
            do
            {
                p = rect.GetRandomPoint(random);
            } while (Vector2.Distance(p,rect.center) < minDistanceFromCameraCentre);
                       
            Quaternion r = Quaternion.Euler(0, 0, (float)(random.NextDouble() * 360));
            Asteroid newAsteroid = Instantiate(asteroidPrefab, p, r, transform);
            newAsteroid.Setup(random);
        }

        //restartButton.onClick.AddListener(RestartGame);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Camera.main.GetRect().center, minDistanceFromCameraCentre);
    }

    public void RestartGame()  // Called from Button
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnAsteroidCountChanged() 
    {
        asteroidCountText.text = "Asteroids: " + livingAsteroids.Count;
    }
}

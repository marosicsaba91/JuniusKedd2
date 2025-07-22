using System;
using System.Collections;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    [SerializeField] KeyCode bulletTimeButton = KeyCode.RightControl;
    [SerializeField] AnimationCurve bulletTimeScale;
    [SerializeField] float duration;

    bool bulletTimeEnabled = true;

    void Update()
    {
        if (bulletTimeEnabled && Input.GetKeyDown(bulletTimeButton))
        {
            StartCoroutine(BulletTime());        
        }        
    }

    IEnumerator BulletTime()
    {
        bulletTimeEnabled = false;
        float t = 0;

        while (t < duration)
        {
            Time.timeScale = bulletTimeScale.Evaluate(t);
            t += Time.unscaledDeltaTime;
            yield return null;
        }
        bulletTimeEnabled = true;
    }
}

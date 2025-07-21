using System;
using UnityEngine;

[ExecuteAlways]
public class ObjectSequence : MonoBehaviour
{
    [SerializeField] Transform[] transforms;

    void Update()
    {
        if (Application.isPlaying)
            PlayModeUpdate();
        else
            EditorModeUpdate();
    }

    void PlayModeUpdate()
    {
        // ...
    }

    bool EditorModeUpdate()
    {

        if (transforms == null || transforms.Length < 3)
            return false;

        Transform starT = transforms[0];
        Transform endT = transforms[^1];
        Vector3 star = starT.position;
        Vector3 end = endT.position;

        //Vector3 distanceV = end - star;
        //Vector3 step = distanceV / (transforms.Length - 1);

        for (int i = 1; i < transforms.Length - 1; i++)
        {
            Transform middle = transforms[i];
            //middle.position = star + (step * i);

            float t = (float)i / (transforms.Length - 1);
            middle.position = Vector3.LerpUnclamped(star, end, t);
        }

        return true;
    }
}

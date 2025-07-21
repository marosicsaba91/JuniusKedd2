using System.Collections.Generic;
using UnityEngine;

class FollowClosest : MonoBehaviour
{
    [SerializeField] Transform[] objects;
    [SerializeField] float speed = 10;

    List<Transform> all;
    void Start()
    {
        all = new();
        all.AddRange(objects);
        all.Sort(Closest);
    }

    int Closest(Transform a, Transform b)
    {
        float da = Vector3.Distance(a.position, transform.position);
        float db = Vector3.Distance(b.position, transform.position);
        return (int)Mathf.Sign(da - db);
    }

    void Update()
    {
        if (all.Count == 0)
            return;

        Transform target = all[0];

        // target = GetClosest();

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime);

        if (transform.position == target.position)
            all.Remove(target);
    }

    Transform GetClosest()
    {
        Vector3 cp = transform.position;
        float min = float.MaxValue;
        Transform target = null;
        foreach (Transform t in all)
        {
            float d = Vector3.Distance(cp, t.position);
            if (d < min)
            {
                min = d;
                target = t;
            }
        }

        return target;
    }

    static float Min(float[] floats)
    {
        float min = floats[0];
        for (int i = 1; i < floats.Length; i++)
        {
            float item = floats[i];
            if (item < min)
                min = item;
        }
        return min;
    }

    void OnDrawGizmos()
    {
        Transform closest = GetClosest();
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, closest.position);
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    static public Vector3 POS = Vector3.zero;

    [Header("Box Movement")]
    public Vector3 boxSize = new Vector3(50f, 0f, 50f);
    public float speed = 10f;
    public float y = 40f;

    void FixedUpdate()
    {
        float perim = 2f * (boxSize.x + boxSize.z);
        if (perim <= 0f) return;

        float d = Time.time * speed % perim;
        float halfX = boxSize.x * 0.5f;
        float halfZ = boxSize.z * 0.5f;
        Vector3 tPos;

        if (d < boxSize.x)
        {
            tPos = new Vector3(-halfX + d, y, -halfZ);
        }
        else if (d < boxSize.x + boxSize.z)
        {
            tPos = new Vector3(halfX, y, -halfZ + (d - boxSize.x));
        }
        else if (d < boxSize.x * 2f + boxSize.z)
        {
            tPos = new Vector3(halfX - (d - (boxSize.x + boxSize.z)), y, halfZ);
        }
        else
        {
            tPos = new Vector3(-halfX, y, halfZ - (d - (boxSize.x * 2f + boxSize.z)));
        }

        transform.position = tPos;
        POS = tPos;
    }
}

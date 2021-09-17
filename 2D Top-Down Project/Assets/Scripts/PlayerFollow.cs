using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 yOffset;

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + yOffset;

    }
}

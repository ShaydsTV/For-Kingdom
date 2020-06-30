using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float timeOffset;
    public Vector3 offset;

    private Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, timeOffset);
    }
}

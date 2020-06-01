using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float smoothspeed = 5f;
    public Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }
    private void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothspeed * Time.deltaTime);
    }
}

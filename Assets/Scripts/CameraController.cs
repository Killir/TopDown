using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    public Vector3 offset;
    public Transform target;

    void LateUpdate()
    {
        if (target) {
            Vector3 targetPosition = target.position + offset;
            float distance = (targetPosition - transform.position).magnitude;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * distance * Time.deltaTime);
        }
    }
}

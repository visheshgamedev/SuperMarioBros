using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        if (playerTransform.position.x > transform.position.x)
        {
            Vector3 desiredPosition = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
            Vector3 smoothCameraPosition = Vector3.Lerp(transform.position, desiredPosition, 10f * Time.deltaTime);
            transform.position = smoothCameraPosition;
        }
    }
}
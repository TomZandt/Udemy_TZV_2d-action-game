using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float cameraSpeed = 0.05f;

    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    //****************************************************************************************************
    private void Start()
    {
        transform.position = playerTransform.position;
    }

    //****************************************************************************************************
    private void Update()
    {
        if(playerTransform != null)
        {
            float clampedX = Mathf.Clamp(playerTransform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(playerTransform.position.y, minY, maxY);

            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), cameraSpeed);
        }
    }
}

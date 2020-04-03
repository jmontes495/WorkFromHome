using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;

    float windowBorderDelta = 10;

    void Update()
    {
        if (Input.mousePosition.x >= Screen.width - windowBorderDelta && transform.position.x <= rightLimit)
            transform.position += Vector3.right * Time.deltaTime * cameraSpeed;

        if (Input.mousePosition.x <= 0 + windowBorderDelta && transform.position.x > leftLimit)
            transform.position -= Vector3.right * Time.deltaTime * cameraSpeed;        
    }
}

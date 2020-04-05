using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float livingRoomLimit;
    [SerializeField] private float babyRoomLimit;
    [SerializeField] private CameraPointers cameraPointers;
    [SerializeField] private FilthyRoom filthyRoom;
    [SerializeField] private BabyHappiness babyHappiness;

    float windowBorderDelta = 10;

    void Update()
    {
        if (Input.mousePosition.x >= Screen.width - windowBorderDelta && transform.position.x <= rightLimit)
            transform.position += Vector3.right * Time.deltaTime * cameraSpeed;

        if (Input.mousePosition.x <= 0 + windowBorderDelta && transform.position.x > leftLimit)
            transform.position -= Vector3.right * Time.deltaTime * cameraSpeed;

        cameraPointers.ActivateLeftArrow(transform.position.x > leftLimit + 0.5f);
        cameraPointers.ActivateRightArrow(transform.position.x < rightLimit - 0.5f);
        cameraPointers.ActivateDirtyIndicatorLeft(filthyRoom.IsFilthyAF && transform.position.x > livingRoomLimit + 0.5f);
        cameraPointers.ActivateDirtyIndicatorRight(filthyRoom.IsFilthyAF && transform.position.x < babyRoomLimit - 0.5f);
        cameraPointers.ActivateCryingIndicator(babyHappiness.IsCrying && transform.position.x > babyRoomLimit + 0.5f);
    }
}

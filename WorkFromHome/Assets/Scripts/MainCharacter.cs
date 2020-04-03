using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private bool isMoving;
    private Vector3 currentTarget;
    private float cameraAdjustment = -0.01f;

    public void MoveToDirection(Vector3 newDirection)
    {
        isMoving = true;
        //currentTarget = new Vector3(newDirection.x, newDirection.y, transform.position.z);
        currentTarget = new Vector3(newDirection.x, newDirection.y, newDirection.z + cameraAdjustment);
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, currentTarget) < 0.001f)
                isMoving = false;
        }
    }
}

using System;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private bool isMoving;
    private Vector3 currentTarget;
    private float cameraAdjustment = -0.01f;

    private Action actionWhenArrived;

    public void MoveToDirection(Vector3 newDirection, Action whenArrived)
    {
        isMoving = true;
        //currentTarget = new Vector3(newDirection.x, newDirection.y, transform.position.z);
        currentTarget = new Vector3(newDirection.x, newDirection.y, newDirection.z + cameraAdjustment);
        actionWhenArrived = whenArrived;
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, currentTarget) < 0.001f)
            {
                isMoving = false;
                if(actionWhenArrived != null)
                    actionWhenArrived();
                actionWhenArrived = null;
            }
        }
    }
}

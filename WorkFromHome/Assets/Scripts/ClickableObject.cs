using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    private ObjectSelectionController selectionController;

    private void Start()
    {
        selectionController = transform.parent.GetComponent<ObjectSelectionController>();
    }

    private void OnMouseDown()
    {
        selectionController.ObjectWasClicked(this); 
    }
}

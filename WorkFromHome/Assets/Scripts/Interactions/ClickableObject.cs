using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    [SerializeField] private InteractionType interactionType;
    private ObjectSelectionController selectionController;

    private void Start()
    {
        selectionController = transform.parent.GetComponent<ObjectSelectionController>();
    }

    private void OnMouseDown()
    {
        selectionController.ObjectWasClicked(this); 
    }

    public InteractionType GetInteractionType()
    {
        return interactionType;
    }
}

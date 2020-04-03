using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelectionController : MonoBehaviour
{
    [SerializeField]
    private MainCharacter player;


    public void ObjectWasClicked(ClickableObject clickedObject)
    {
        player.MoveToDirection(clickedObject.transform.position);
    }
}

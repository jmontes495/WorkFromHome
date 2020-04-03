using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelectionController : MonoBehaviour
{
    [SerializeField] private MainCharacter player;
    [SerializeField] private GameVariablesController gameVariables;

    private InteractionType currentObjective;
    private InteractionType currentAction;

    public void ObjectWasClicked(ClickableObject clickedObject)
    {
        ChangedObjective(clickedObject.GetInteractionType());
        currentObjective = clickedObject.GetInteractionType();
        player.MoveToDirection(clickedObject.transform.position, StartAction);
    }

    private void StartAction()
    {
        currentAction = currentObjective;
        switch (currentAction)
        {
            case InteractionType.Computer:
                gameVariables.BeginStream();
                break;
        }
    }

    private void ChangedObjective(InteractionType newType)
    {
        if (currentAction != newType && currentAction == InteractionType.Computer)
            gameVariables.EndStream();
    }
}

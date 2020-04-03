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
        currentAction = InteractionType.None;
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
            case InteractionType.Baby:
                gameVariables.HoldBaby();
                break;
            case InteractionType.Broom:
                gameVariables.StartCleaning();
                break;
        }
    }

    private void ChangedObjective(InteractionType newType)
    {
        if (currentAction != newType)
        {
            switch (currentAction)
            {
                case InteractionType.Computer:
                    gameVariables.EndStream();
                    break;
                case InteractionType.Baby:
                    gameVariables.DropBaby();
                    break;
                case InteractionType.Broom:
                    gameVariables.StopCleaning();
                    break;

            }
        }
    }
}

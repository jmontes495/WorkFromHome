using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelectionController : MonoBehaviour
{
    [SerializeField] private MainCharacter player;
    [SerializeField] private GameVariablesController gameVariables;
    [SerializeField] private MainCharacterAnimator playerAnimator;
    [SerializeField] private AnaCharacterAnimator anaCharacterAnimator;

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
        player.transform.localScale = Vector3.one * 0.6f;

        switch (currentAction)
        {
            case InteractionType.Computer:
                gameVariables.BeginStream();
                playerAnimator.StartStreaming();
                break;
            case InteractionType.Baby:
                gameVariables.HoldBaby();
                playerAnimator.StartPlaying();
                anaCharacterAnimator.StartPlaying();
                break;
            case InteractionType.Broom:
                gameVariables.StartCleaning();
                playerAnimator.StartCleaning();
                break;
        }
    }

    private void ChangedObjective(InteractionType newType)
    {
        if (currentAction != newType)
        {
            player.transform.localScale = Vector3.one * 0.8f;
            playerAnimator.SetNeutral();
            playerAnimator.CheckDirection(currentAction, newType);

            switch (currentAction)
            {
                case InteractionType.Computer:
                    gameVariables.EndStream();
                    break;
                case InteractionType.Baby:
                    gameVariables.DropBaby();
                    anaCharacterAnimator.StopPlaying();
                    break;
                case InteractionType.Broom:
                    gameVariables.StopCleaning();
                    break;

            }
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainCharacterAnimator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer mainCharacter;
    [SerializeField] private float animationSpeed;
    [SerializeField] private List<Sprite> neutral;
    [SerializeField] private List<Sprite> streaming;
    [SerializeField] private List<Sprite> cleaning;
    [SerializeField] private List<Sprite> playing;

    private List<Sprite> currentAnimation;
    private Tween currentTween;
    private int currentFrame;

    private void Start()
    {
        SetNeutral();
    }

    private void StartAnimation()
    {
        if (currentTween != null)
            currentTween.Kill();

        currentTween = DOVirtual.DelayedCall(animationSpeed, () =>
        {
            currentFrame++;
            if (currentFrame > currentAnimation.Count - 1)
                currentFrame = 0;

            mainCharacter.sprite = currentAnimation[currentFrame];
        }).SetLoops(-1);
    }

    private void StopAnimation()
    {
        if (currentTween != null)
            currentTween.Kill();
    }

    public void CheckDirection(InteractionType previous, InteractionType next)
    {
        int direction = 1;

        if ((previous == InteractionType.Computer && next == InteractionType.Broom) || (previous == InteractionType.Computer && next == InteractionType.Baby) || (previous == InteractionType.Broom && next == InteractionType.Baby))
            direction = -1;

        mainCharacter.transform.localScale = new Vector3(Mathf.Abs(mainCharacter.transform.localScale.x) * direction, mainCharacter.transform.localScale.y, mainCharacter.transform.localScale.z);
    }

    public void SetNeutral()
    {
        currentAnimation = neutral;
        currentFrame = 0;
        mainCharacter.sprite = neutral[currentFrame];
        StopAnimation();
    }

    public void StartStreaming()
    {
        currentAnimation = streaming;
        currentFrame = 0;
        mainCharacter.sprite = streaming[currentFrame];
        StartAnimation();
    }

    public void StartCleaning()
    {
        currentAnimation = cleaning;
        currentFrame = 0;
        mainCharacter.sprite = cleaning[currentFrame];
        StartAnimation();
    }

    public void StartPlaying()
    {
        currentAnimation = playing;
        currentFrame = 0;
        mainCharacter.sprite = playing[currentFrame];
        StartAnimation();
    }
}

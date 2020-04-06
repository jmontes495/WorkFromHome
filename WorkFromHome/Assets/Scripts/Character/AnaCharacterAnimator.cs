using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnaCharacterAnimator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer anaCharacter;
    [SerializeField] private BabyHappiness babyHappiness;
    [SerializeField] private float animationSpeed;
    [SerializeField] private List<Sprite> happy;
    [SerializeField] private List<Sprite> crying;
    [SerializeField] private List<Sprite> playing;

    private List<Sprite> currentAnimation;
    private Tween currentTween;
    private int currentFrame;
    private int currentClothesLayer;
    private bool isPlaying = false;
    private bool isCrying = false;

    private void Start()
    {
        isPlaying = false;
        isCrying = false;
        SetHappy();
    }

    private void Update()
    {
        if(!isPlaying)
        {
            if(isCrying != babyHappiness.IsCrying)
            {
                isCrying = babyHappiness.IsCrying;
                if (isCrying)
                    SetCrying();
                else
                    SetHappy();
            }
        }
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

            anaCharacter.sprite = currentAnimation[currentFrame];
        }).SetLoops(-1);
    }

    private void StopAnimation()
    {
        if (currentTween != null)
            currentTween.Kill();
    }

    public void SetHappy()
    {
        currentAnimation = happy;
        currentFrame = 0;
        anaCharacter.sprite = happy[currentFrame];
        StartAnimation();
    }

    public void SetCrying()
    {
        currentAnimation = crying;
        currentFrame = 0;
        anaCharacter.sprite = crying[currentFrame];
        StartAnimation();
    }

    public void StartPlaying()
    {
        isPlaying = true;
        currentAnimation = playing;
        currentFrame = 0;
        anaCharacter.sprite = playing[currentFrame];
        StartAnimation();
    }

    public void StopPlaying()
    {
        isPlaying = false;
    }
}

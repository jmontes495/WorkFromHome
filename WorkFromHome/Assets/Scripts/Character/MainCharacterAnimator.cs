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
    [SerializeField] private List<Sprite> neutral2;
    [SerializeField] private List<Sprite> streaming2;
    [SerializeField] private List<Sprite> cleaning2;
    [SerializeField] private List<Sprite> playing2;

    private List<Sprite> currentAnimation;
    private Tween currentTween;
    private int currentFrame;
    private int currentClothesLayer;

    private void Start()
    {
        currentClothesLayer = 0;
        SetNeutral();
    }

    //Cheat for clothes
    //private void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.Alpha1))
    //    {
    //        currentClothesLayer = -1;
    //        UpdateClothes();
    //    }
    //    else if (Input.GetKeyUp(KeyCode.Alpha2))
    //    {
    //        currentClothesLayer = 0;
    //        UpdateClothes();
    //    }
    //    else if (Input.GetKeyUp(KeyCode.Alpha3))
    //    {
    //        currentClothesLayer = 1;
    //        UpdateClothes();
    //    }
    //    else if (Input.GetKeyUp(KeyCode.Alpha4))
    //    {
    //        currentClothesLayer = 2;
    //        UpdateClothes();
    //    }
    //}

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

    public void UpdateClothes()
    {
        currentClothesLayer++;
        if (currentAnimation.Equals(neutral))
            SetNeutral();
        else if (currentAnimation.Equals(streaming))
            StartStreaming();
        else if (currentAnimation.Equals(cleaning))
            StartCleaning();
        else if (currentAnimation.Equals(playing))
            StartPlaying();

        Debug.Log("Updated clothes");
    }

    public void SetNeutral()
    {
        if (currentClothesLayer == 1)
        {
            currentAnimation = neutral2;

        }
        else
            currentAnimation = neutral;

        currentFrame = 0;
        mainCharacter.sprite = currentAnimation[currentFrame];
        StopAnimation();
    }

    public void StartStreaming()
    {
        if (currentClothesLayer == 1)
            currentAnimation = streaming2;
        else
            currentAnimation = streaming;

        currentFrame = 0;
        mainCharacter.sprite = currentAnimation[currentFrame];
        StartAnimation();
    }

    public void StartCleaning()
    {
        if (currentClothesLayer == 1)
            currentAnimation = cleaning2;
        else
            currentAnimation = cleaning;

        currentFrame = 0;
        mainCharacter.sprite = currentAnimation[currentFrame];
        StartAnimation();
    }

    public void StartPlaying()
    {
        if (currentClothesLayer == 1)
            currentAnimation = playing2;
        else
            currentAnimation = playing;

        currentFrame = 0;
        mainCharacter.sprite = currentAnimation[currentFrame];
        StartAnimation();
    }

    private void OnDestroy()
    {
        StopAnimation();
    }
}

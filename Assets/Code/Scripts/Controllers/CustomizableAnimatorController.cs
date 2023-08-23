using System;
using System.Collections.Generic;
using UnityEngine;

public class CustomizableAnimatorController : HumanAnimatorController
{
    class AnimationClipOverrides : List<KeyValuePair<AnimationClip, AnimationClip>>
    {
        public AnimationClipOverrides(int capacity) : base(capacity) { }

        public AnimationClip this[string name]
        {
            get { return this.Find(x => x.Key.name.Equals(name)).Value; }
            set
            {
                int index = this.FindIndex(x => x.Key.name.Equals(name));
                if (index != -1)
                    this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
            }
        }
    }
    [SerializeField]
    private string[] bodyPartTypes;

    [SerializeField]
    private string[] characterStates;

    [SerializeField]
    private string[] characterDirections;

    [SerializeField]
    private CharacterBody_SO characterBody;

    private AnimationClip animationClip;
    private AnimatorOverrideController animatorOverrideController;
    private AnimationClipOverrides defaultAnimationClips;

    protected override void Awake()
    {
        base.Awake();

        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;

        defaultAnimationClips = new AnimationClipOverrides(animatorOverrideController.overridesCount);
        animatorOverrideController.GetOverrides(defaultAnimationClips);

        EventsPool.Instance.AddListener(typeof(UpdateCharacterPartsEvent), new Action(UpdateBodyParts));

    }
    private void Start()
    {
        UpdateBodyParts();
    }

    private void UpdateBodyParts()
    {
        List<BodyPart_SO> parts = new List<BodyPart_SO>()
        {
            characterBody.headBodyPart,
            characterBody.clothesBodyPart
        };

        for (int partIndex = 0; partIndex < bodyPartTypes.Length; partIndex++)
        {
            string partType = bodyPartTypes[partIndex];

            string partID = parts[partIndex] == null ? "0" : parts[partIndex].partAnimationID.ToString();

            for (int stateIndex = 0; stateIndex < characterStates.Length; stateIndex++)
            {
                string state = characterStates[stateIndex];
                for (int directionIndex = 0; directionIndex < characterDirections.Length; directionIndex++)
                {
                    string direction = characterDirections[directionIndex];

                    animationClip = Resources.Load<AnimationClip>("Player Animations/" + partType + "/" + partType + "_" + partID + "_" + state + "_" + direction);

                    // Override default animation
                    defaultAnimationClips[partType + "_" + 0 + "_" + state + "_" + direction] = animationClip;
                }
            }
        }
        animatorOverrideController.ApplyOverrides(defaultAnimationClips);
    }
}

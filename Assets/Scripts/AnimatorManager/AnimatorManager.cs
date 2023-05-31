using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

public class AnimatorManager : Singleton<AnimatorManager>
{
    public Animator animator;
    public List<AnimatorSetup> animatorSetups;

    public enum AnimationType
    {
        IDLE,
        RUN,
        DEATH
    }

    public void Play(AnimationType type, float speedFactor = 1f)
    {
        foreach (var setup in animatorSetups)
        {
            if (setup.type == type)
            {
                animator.SetTrigger(setup.trigger);
                animator.speed = setup.speed * speedFactor;
                break;
            }
        }
    }

    [System.Serializable]
    public class AnimatorSetup
    {
        public AnimatorManager.AnimationType type;
        public string trigger;
        public float speed = 1f;
    }
}

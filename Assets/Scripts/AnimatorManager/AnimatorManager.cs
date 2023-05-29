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

    public void Play(AnimationType type)
    {
        foreach (var setup in animatorSetups)
        {
            if (setup.type == type)
            {
                animator.SetTrigger(setup.trigger);
                break;
            }
        }
    }

    [System.Serializable]
    public class AnimatorSetup
    {
        public AnimatorManager.AnimationType type;
        public string trigger;
    }
}

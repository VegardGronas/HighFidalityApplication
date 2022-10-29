using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleAnimation;

public class AnimationManager : SimpleAnimatoionManager
{
    public void AnimateToTarget()
    {
        StartAnimateTo();
    }

    public void AnimateToStartPos()
    {
        StartAnimateBack();
    }
}

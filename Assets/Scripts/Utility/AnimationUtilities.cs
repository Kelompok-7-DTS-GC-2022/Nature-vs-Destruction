using System.Collections;
using UnityEngine;

public class AnimationUtilities
{
    public IEnumerator waitAnimationToDestroy(Animator animator, string animationName)
    {
        bool isDone = false;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName(animationName) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > animator.GetCurrentAnimatorStateInfo(0).length)
        {
            // Debug.Log("Yieeellllddd");
            isDone = true;
        }
        yield return new WaitUntil(() => isDone == true);
    }
}
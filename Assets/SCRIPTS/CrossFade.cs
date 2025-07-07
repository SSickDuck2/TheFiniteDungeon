using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CrossFade : SceneTransition
{
    public CanvasGroup canvasGroup;
    public override IEnumerator AnimateTransitionIn()
    {
        var tweener = canvasGroup.DOFade(1f,1f);
        yield return tweener.WaitForCompletion();
    }

    public override IEnumerator AnimateTransitionOut()
    {
        var tweener = canvasGroup.DOFade(0f,1f);
        yield return tweener.WaitForCompletion();
    }
}

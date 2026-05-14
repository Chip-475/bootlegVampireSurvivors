using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class xpBar : MonoBehaviour  // ATTACHED TO PLAYER
{
    [Header("XP Bar")]
    public Image xpBarObject;
    public AnimationCurve xpBarCurve;
    public float animTime;

    public bool queueing;
    public float queueTimer;
    public GameObject cardsLabel;
    public void startMedium()
    {
        StartCoroutine(xpBarSetGain());
    }

    public IEnumerator xpBarSetGain()
    {
        queueing = true;

        float t = 0f;
        float totGain = 0f;
        while (t < queueTimer)
        {
            if (data.xpQueue.Count > 0)
            {
                t = 0f;
                totGain += data.xpQueue.Dequeue();
            }
            t += Time.deltaTime;
            yield return null;
        }
        yield return StartCoroutine(xpBarMovement(totGain));
        if (data.xpQueue.Count > 0) yield return StartCoroutine(xpBarSetGain());

        queueing = false;
    }
    public IEnumerator xpBarMovement(float totGain)
    {
        float currentXp = xpBarObject.fillAmount * data.xpMax;
        data.xp = currentXp;
        float toGain = Mathf.Min(totGain, data.xpMax - currentXp);
        float overflow = totGain - toGain;

        xpBarCurve = AnimationCurve.EaseInOut(0, xpBarObject.fillAmount, animTime, (currentXp + toGain) / data.xpMax);

        var t = 0f;
        while (t < animTime)
        {
            xpBarObject.fillAmount = xpBarCurve.Evaluate(t);
            t += Time.deltaTime;
            yield return null;
        }
        xpBarObject.fillAmount = (currentXp + toGain) / data.xpMax;

        if (xpBarObject.fillAmount >= 1) yield return StartCoroutine(levelUp());
        if (overflow > 0f) yield return StartCoroutine(xpBarMovement(overflow));
    }

    public IEnumerator levelUp()
    {
        xpBarObject.fillAmount = 0;
        data.level++;
        data.xp = 0;
        cardsLabel.SetActive(true);
        cardManager.instance.spawnCards();
        data.xpMax += data.xpMax * 0.2f;

        // Level up sfx
        yield return null;
    }
}

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

    public void startMedium()
    {
        StartCoroutine(xpBarSetGain());
    }

    public IEnumerator xpBarSetGain()
    {
        queueing = true;
        float t = 0f;
        float totGain = 0f;
        while(t < queueTimer)
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
        queueing = false;
    }
    public IEnumerator xpBarMovement(float totGain)
    {
        float toGain = 0f;
        float overflow = 0f;
        if(totGain <= data.xpMax)
        {
            toGain = totGain;
        }
        else
        {
            toGain = data.xpMax;
            overflow = totGain - data.xpMax;
        }
        xpBarCurve = AnimationCurve.EaseInOut(0, xpBarObject.fillAmount, animTime, xpBarObject.fillAmount + (toGain / data.xpMax));

        var t = 0f;
        while (t < animTime)
        {
            xpBarObject.fillAmount = xpBarCurve.Evaluate(t);
            t += Time.deltaTime;
            yield return null;
        }
        if (overflow > 0f) { xpBarObject.fillAmount = 0; yield return StartCoroutine(xpBarMovement(overflow)); }
    }
}

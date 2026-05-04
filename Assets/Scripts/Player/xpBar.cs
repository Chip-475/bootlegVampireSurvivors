using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class xpBar : MonoBehaviour
{
    [Header("XP Bar")]
    public Image xpBarObject;
    public AnimationCurve xpBarCurve;
    public float animTime;

    public IEnumerator xpBarMovement()
    {
        var x = 0f;
        while (x < animTime)
        {
            xpBarObject.fillAmount = xpBarCurve.Evaluate(x);
            x += Time.deltaTime;
            yield return null;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class hpBar : MonoBehaviour
{
    [Header("HP Bar")]
    public Image hpBarObject;
    public AnimationCurve hpBarCurve;
    public float animTime;

    public IEnumerator hpBarMovement()
    {
        var x = 0f;
        while (x < animTime)
        {
            hpBarObject.fillAmount = hpBarCurve.Evaluate(x);
            x += Time.deltaTime;
            yield return null;
        }
    }
}

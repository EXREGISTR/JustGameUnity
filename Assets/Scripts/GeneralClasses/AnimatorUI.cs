using System.Collections;
using UnityEngine;

public class AnimatorUI : MonoBehaviour
{
    /// <summary>
    /// Плавное проявление интерфейса
    /// </summary>
    /// <param name="groupControls"></param>
    /// <param name="timeAppearance"></param>
    /// <param name="startAlpha"></param>
    /// <param name="finalAlpha"></param>
    public void StartAppearance(CanvasGroup groupControls, float timeAppearance, float startAlpha = 0f, float finalAlpha = 1f)
    {
        groupControls.alpha = startAlpha;
        var speedAppearance = (finalAlpha - startAlpha) / timeAppearance;
        StartCoroutine(Appearance(groupControls, finalAlpha, speedAppearance));
    }

    /// <summary>
    /// Плавное затухание интерфейса
    /// </summary>
    /// <param name="groupControls"></param>
    /// <param name="timeAttenuation"></param>
    /// <param name="finalAlpha"></param>
    public void StartAttenuation(CanvasGroup groupControls, float timeAttenuation, float finalAlpha = 0f)
    {
        var speedAppearance = Mathf.Abs((finalAlpha - groupControls.alpha) / timeAttenuation);
        StartCoroutine(Attenuation(groupControls, finalAlpha, speedAppearance));
    }

    private IEnumerator Appearance(CanvasGroup groupControls, float finalAlpha, float speedAppearance)
    {
        while (groupControls.alpha <= finalAlpha)
        {
            groupControls.alpha += speedAppearance * Time.fixedDeltaTime;
            yield return null;
        }
    }
    private IEnumerator Attenuation(CanvasGroup groupControls, float finalAlpha, float speedAppearance)
    {
        while (groupControls.alpha > finalAlpha)
        {
            groupControls.alpha -= speedAppearance * Time.fixedDeltaTime;
            yield return null;
        }
    }
}

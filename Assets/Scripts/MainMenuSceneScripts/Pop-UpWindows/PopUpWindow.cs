using UnityEngine;

public abstract class PopUpWindow : MonoBehaviour
{
    public abstract void SetVisible(bool value);

    protected void Visible(bool value, AnimatorUI animatorUI, CanvasGroup canvasGroup, float timeAnimation)
    {
        MainMenuUI.SetInterectable(!value);

        if (value)
            animatorUI.StartAppearance(groupControls: canvasGroup, timeAnimation);

        else
            animatorUI.StartAttenuation(groupControls: canvasGroup, timeAnimation);
    }
}

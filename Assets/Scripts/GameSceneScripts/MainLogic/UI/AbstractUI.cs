using TMPro;
using UnityEngine;

public abstract class AbstractUI : MonoBehaviour
{
    protected virtual void InteractionWithUI() { }
    protected void ChangeText(TMP_Text controlText, string text)
    {
        controlText.text = text;
    }
}

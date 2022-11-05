using TMPro;
using UnityEngine;

public sealed class DeathMenuUI : AbstractUI
{
    #region SerializeFields
    [SerializeField] private AnimatorUI _AnimatorUI;
    [SerializeField] private TMP_Text Result;
    #endregion

    #region PrivateFields
    private CanvasGroup _canvasGroup;
    private PlayerData _playerData;
    #endregion

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _playerData = PlayerData.GetInstance();
    }

    public void Show(float totalPoints)
    {
        string text;
        if (totalPoints > _playerData.Record && _playerData.Record != 0f)
            text = $"NEW RECORD!\n" +
                $"{totalPoints} PTS";
        else
            text = $"RECEIVED {totalPoints} PTS";

        ChangeText(controlText: Result, text);
        // плавное проявление
        _AnimatorUI.StartAppearance(groupControls: _canvasGroup, timeAppearance: 1f);
    }
}

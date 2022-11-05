using TMPro;
using UnityEngine;

public class StatisticsWindow : PopUpWindow
{
    #region SerializeFields
    [SerializeField] private AnimatorUI _AnimatorUI;
    [SerializeField] private TMP_Text DateRegister;
    [SerializeField] private TMP_Text Statistics;
    #endregion

    #region PrivateFields
    private CanvasGroup _canvasGroup;
    private PlayerData _playerData;
    #endregion

    #region UnityMethods
    public void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _playerData = PlayerData.GetInstance();

        Statistics.text = _playerData.GetStatistics();
        DateRegister.text = "The first entry in game was\n" +
            $"{_playerData.DateRegister}";
    }
    #endregion

    #region Methods
    public override void SetVisible(bool value)
    {
        if (value)
        {
            gameObject.SetActive(value);
            base.Visible(value, _AnimatorUI, _canvasGroup, timeAnimation: 0.01f);
        }
        else
        {
            base.Visible(value, _AnimatorUI, _canvasGroup, timeAnimation: 0.1f);
            gameObject.SetActive(value);
        }
    }
    #endregion
}
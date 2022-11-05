using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    #region SerializeFields
    [SerializeField] private RegisterWindow RegisterWindow;
    #endregion

    #region PrivateFields
    private AnimatorUI _animatorUI;
    private PlayerData _playerData;

    private static CanvasGroup _mainUIGroup;
    #endregion

    #region UnityMethods
    private void Awake()
    {
        _playerData = PlayerData.GetInstance();
        _animatorUI = GetComponent<AnimatorUI>();
        _mainUIGroup = GetComponent<CanvasGroup>();
    }
    private void Start()
    {
        // плавное проявление контролов
        _animatorUI.StartAppearance(groupControls: _mainUIGroup, timeAppearance: 2.5f);
        if (_playerData.Name is null)
            RegisterWindow.SetVisible(true);
    }
    #endregion

    #region Methods
    public static void SetInterectable(bool value)
    {
        _mainUIGroup.interactable = value;
    }
    #endregion
}

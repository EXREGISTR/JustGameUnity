using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegisterWindow : PopUpWindow
{
    #region SerializeFields
    [SerializeField] private AnimatorUI _AnimatorUI;
    [SerializeField] private Text ErrorText;
    [SerializeField] private TMP_InputField InputField;
    #endregion

    #region PrivateFields
    private PlayerData _playerData;
    private CanvasGroup _canvasGroup;
    private bool _mayCreateAccount;
    #endregion

    #region UnityMethods
    private void Awake()
    {
        _playerData = PlayerData.GetInstance();
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    #endregion

    #region EventsMethods
    // вызывается каждый раз при изменении текста в поле
    public void OnValueChanged()
    {
        if (InputField.text == "")
        {
            VisibleError(false);
            _mayCreateAccount = false;
            return;
        }
        else if (!_playerData.CheckInputName(InputField.text))
        {
            VisibleError(true, "Введены некорректные символы!");
            _mayCreateAccount = false;
            return;
        }
        else
        {
            VisibleError(false);
            _mayCreateAccount = true;
            return;
        }
    }

    // выполняется при нажатии на кнопку создания "аккаунта"
    public void OnClickCreate()
    {
        if (_mayCreateAccount)
        {
            _playerData.SetName(InputField.text);
            _playerData.Save();
            SetVisible(false);
        }
    }
    #endregion

    #region Methods
    public override void SetVisible(bool value)
    {
        if (value)
        {
            gameObject.SetActive(value);
            base.Visible(value, _AnimatorUI, _canvasGroup, timeAnimation: 1f);
        }
            
        else
        {
            base.Visible(value, _AnimatorUI, _canvasGroup, timeAnimation: 1f);
            gameObject.SetActive(value);
        }
    }

    private void VisibleError(bool value, string errorText = null)
    {
        ErrorText.text = errorText;
        ErrorText.gameObject.SetActive(value);
    }
    #endregion
}

using TMPro;
using UnityEngine;

public sealed class GameUI : AbstractUI
{
    [HideInInspector] public bool IsFinishGame { get; private set; }

    #region SerializeFields
    [SerializeField] private AnimatorUI _AnimatorUI;
    [SerializeField] private PauseUI _PauseUI;
    [SerializeField] private DeathMenuUI _DeathMenuUI;
    #endregion

    #region PrivateFields
    private PlayerData _playerData;
    private CanvasGroup _canvasGroup;
    private TMP_Text _points;
    private float _currentPointsCount;
    #endregion

    #region UnityMethods
    private void Awake()
    {
        _playerData = PlayerData.GetInstance();
        _canvasGroup = GetComponent<CanvasGroup>();
        _points = GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        _AnimatorUI.StartAppearance(groupControls: _canvasGroup, timeAppearance: 5f);
    }

    private void OnEnable()
    {
        PlayerStrategy.PlayerDestroyEvent += FinishGame;
        PlayerStrategy.PlayerDestroyEvent += UpdateStatisticsPlayer;
        ObstacleStrategy.OnUpdatePointsEvent += UpdatePoints;
        Time.timeScale = 1;
    }

    private void OnDisable()
    {
        PlayerStrategy.PlayerDestroyEvent -= FinishGame;
        PlayerStrategy.PlayerDestroyEvent -= UpdateStatisticsPlayer;
        ObstacleStrategy.OnUpdatePointsEvent -= UpdatePoints;
        Time.timeScale = 1;
    }
    #endregion

    #region Methods
    private void UpdatePoints(float pointsCount)
    {
        _currentPointsCount += pointsCount;
        string text = $"Points: {_currentPointsCount}";
        ChangeText(controlText: _points, text);
    }

    private void FinishGame()
    {
        IsFinishGame = true;
        // выкл основной интерфейс игры
        gameObject.SetActive(false);
        // вкл меню после уничтожения
        _DeathMenuUI.gameObject.SetActive(true);
        _DeathMenuUI.Show(_currentPointsCount);
    }

    private void UpdateStatisticsPlayer()
    {
        // если набранное число очков больше рекорда то записываем новый рекорд
        if (_currentPointsCount > _playerData.Record)
            _playerData.Record = _currentPointsCount;

        // увеличиваем число набранных очков за все время и увеличиваем количество сыгранных игр
        _playerData.TotalPoints += _currentPointsCount;
        _playerData.GamesCount++;
        // сохраняемся
        _playerData.Save();
    }
    #endregion
}

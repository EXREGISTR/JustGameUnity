using System;
using UnityEngine;

public sealed class PauseUI : AbstractUI
{
    [SerializeField] private GameUI _GameUI;
    [SerializeField] private AnimatorUI AnimatorUI;

    private CanvasGroup _canvasGroup;
    private bool IsPause;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (!_GameUI.IsFinishGame)
            InteractionWithUI();
    }

    public void OnPause()
    {
        _GameUI.gameObject.SetActive(false);
        IsPause = true;
        gameObject.SetActive(true);
        AnimatorUI.StartAppearance(groupControls: _canvasGroup, timeAppearance: 0.1f);
        Time.timeScale = 0;
    }
    
    public void OffPause()
    {
        _GameUI.gameObject.SetActive(true);
        IsPause = false;
        gameObject.SetActive(false);
        AnimatorUI.StartAttenuation(groupControls: _canvasGroup, timeAttenuation: 0.1f);
        Time.timeScale = 1;
    }
    
    protected override void InteractionWithUI()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            (IsPause ? (Action)OffPause : OnPause)();
        }
    }
}

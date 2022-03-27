using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DinerMinigame : Minigame
{
    [SerializeField] private Button _callButton;
    [SerializeField] private DinerTimerHandler _dinerTimerHandler;
    [SerializeField] private DinerTimerVisual _dinerTimerVisual;
    [SerializeField] private HealthComponent _healthComponent;
    [SerializeField] private List<DinerTimer.Settings> _dinerTimers;

    private Queue<DinerTimer.Settings> _dinerTimerSettingsQueue = new Queue<DinerTimer.Settings>();
    
    public UnityEvent OnSuccess;
    public UnityEvent OnFailed;

    protected override void Awake()
    {
        base.Awake();
        
        _callButton.onClick.AddListener(OnCallButtonClicked);
    }

    public override void StartMinigame(Player player)
    {
        if (IsMinigameFinished) return;
        
        base.StartMinigame(player);
        
        _dinerTimerSettingsQueue = new Queue<DinerTimer.Settings>(_dinerTimers);
        _dinerTimerHandler.CurrentDinerTimer = new DinerTimer(_dinerTimerSettingsQueue.Dequeue());

        _dinerTimerVisual.gameObject.SetActive(true);

        player.MovementComponent.Enabled = false;
    }

    public override void EndMinigame(bool succeeded)
    {
        base.EndMinigame(succeeded);

        _dinerTimerVisual.gameObject.SetActive(false);

        _player.MovementComponent.Enabled = true;
    }

    public override void ResetMiniGame()
    {
        base.ResetMiniGame();
        
        _healthComponent.ResetHealth();
    }

    private void OnCallButtonClicked()
    {
        if (_dinerTimerHandler.IsArrowCorrect)
        {
            if (_dinerTimerSettingsQueue.TryDequeue(out DinerTimer.Settings dinerTimerSettings))
            {
                _dinerTimerHandler.CurrentDinerTimer = new DinerTimer(dinerTimerSettings);
            }
            else
            {
                EndMinigame(_player);
            }
            
            OnSuccess?.Invoke();
        }
        else
        {
            Debug.Log($"{_dinerTimerHandler.CurrentDinerTimer.ArrowAngle % 360f} >= {_dinerTimerHandler.CurrentDinerTimer.SuccessAngle.x % 360f}");
            Debug.Log($"{_dinerTimerHandler.CurrentDinerTimer.ArrowAngle % 360f} <= {_dinerTimerHandler.CurrentDinerTimer.SuccessAngle.y % 360f}");
            OnFailed?.Invoke();
        }
    }
}

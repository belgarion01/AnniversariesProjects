using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class Minigame : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private Transform _resetPoint;
    
    public bool IsMinigameActive { get; protected set; }
    public bool IsMinigameFinished { get; protected set; }
    
    public UnityEvent<Player> OnStart;
    public UnityEvent<Player> OnEnd;
    public UnityEvent OnMinigameSuccess;
    public UnityEvent OnMinigameFailure;
    public UnityEvent OnReset;

    protected Player _player;

    protected virtual void Awake()
    {
        
    }
    
    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        
    }

    public virtual void StartMinigame(Player player)
    {
        _player = player;
        
        if (_virtualCamera != null)
        {
            _virtualCamera.SetOverrideCamera(true);
        }

        IsMinigameActive = true;

        OnStart?.Invoke(player);
    }

    public virtual void EndMinigame(bool succeeded)
    {
        if (_virtualCamera != null)
        {
            _virtualCamera.SetOverrideCamera(false);
        }

        IsMinigameActive = false;
        IsMinigameFinished = succeeded;
        
        OnEnd?.Invoke(_player);
        if (succeeded)
        {
            OnMinigameSuccess?.Invoke();
        }
        else
        {
            OnMinigameFailure?.Invoke();
        }
    }

    public virtual void ResetMiniGame()
    {
        if (_resetPoint != null)
        {
            _player.transform.position = _resetPoint.position;
        }

        EndMinigame(false);
        
        OnReset?.Invoke();
    }
}

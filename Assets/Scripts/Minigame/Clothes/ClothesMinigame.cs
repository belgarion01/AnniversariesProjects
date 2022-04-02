using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class ClothesMinigame : Minigame
{
    [SerializeField] private GameObject[] _barriers;
    [SerializeField] private DifficultySettings[] _difficultySettings;
    [SerializeField] private ClothesSpawner _clothesSpawner;
    [SerializeField] private SimpleTimerUI _timerText;
    [SerializeField] private float _endTime = 60f;
    
    private float _minigameTimer;

    private Queue<DifficultySettings> _difficultyQueue = new Queue<DifficultySettings>();

    protected override void Awake()
    {
        base.Awake();
        
        _difficultyQueue.Clear();
        foreach (DifficultySettings settings in _difficultySettings)
        {
            _difficultyQueue.Enqueue(settings);
        }
    }

    protected override void Start()
    {
        base.Start();
        
        EnableBarriers(false);
    }

    protected override void Update()
    {
        base.Update();
        
        if (!IsMinigameActive) return;
        
        if (_difficultyQueue.TryPeek(out DifficultySettings settings))
        {
            if (_minigameTimer >= settings.Time)
            {
                _clothesSpawner.TimeBetweenSpawn = settings.TimeBetweenSpawn;
                _difficultyQueue.Dequeue();
                
                Debug.Log(_clothesSpawner.TimeBetweenSpawn);
            }
        }

        if (_minigameTimer >= _endTime)
        {
            EndMinigame(_player);
        }

        _minigameTimer += Time.deltaTime;
        _timerText.UpdateText(Mathf.Max(_endTime - _minigameTimer, 0));
    }

    public override void StartMinigame(Player player)
    {
        if (IsMinigameFinished || IsMinigameActive) return;
        base.StartMinigame(player);

        _minigameTimer = 0f;
        
        EnableBarriers(true);
    }

    public override void EndMinigame(bool succeeded)
    {
        base.EndMinigame(succeeded);

        _clothesSpawner.ClearClothes();
        EnableBarriers(false);
    }

    private void EnableBarriers(bool enable)
    {
        foreach (var barrier in _barriers)
        {
            barrier.SetActive(enable);
        }
    }
    
    [Serializable]
    public struct DifficultySettings
    {
        public float Time;
        public float TimeBetweenSpawn;
    }
}

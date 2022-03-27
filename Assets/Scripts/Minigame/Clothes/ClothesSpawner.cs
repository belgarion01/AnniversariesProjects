using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class ClothesSpawner : MonoBehaviour
{
    [SerializeField] private Clothe _clothesPrefab;
    [SerializeField] private Vector2 _spawnArea;
    [SerializeField] private float _defaultTimeBetweenSpawn = 1f;

    public float TimeBetweenSpawn
    {
        get => _timeBetweenSpawn;
        set => _timeBetweenSpawn = value;
    }

    public bool Enabled
    {
        get => _enabled;
        set => _enabled = value;
    }

    public UnityEvent<Clothe> OnClotheHitPlayer;
    
    private float _timer;
    private float _timeBetweenSpawn;

    private bool _enabled = false;

    void Awake()
    {
        _timeBetweenSpawn = _defaultTimeBetweenSpawn;
    }
    
    void Update()
    {
        if (!Enabled) return;

        if (_timer >= _timeBetweenSpawn)
        {
            Spawn();
            ResetTimer();
        }

        _timer += Time.deltaTime;
    }

    public void Spawn()
    {
        Clothe clothe = Instantiate(_clothesPrefab, GetRandomSpawnPosition(), Quaternion.identity, transform);
        clothe.OnPlayerHit.AddListener(c => OnClotheHitPlayer?.Invoke(c));
    }

    public void ResetTimer()
    {
        _timer = 0f;
    }

    public void StartWithDelay(float delay)
    {
        StartCoroutine(StartWithDelayCoroutine(delay));
    }

    public void ClearClothes()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    private Vector2 GetRandomSpawnPosition()
    {
        return new Vector2(Random.Range(-_spawnArea.x, _spawnArea.x)/2f, Random.Range(-_spawnArea.y, _spawnArea.y)/2f) + (Vector2)transform.position;
    }

    IEnumerator StartWithDelayCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        Enabled = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, new Vector3(_spawnArea.x, _spawnArea.y, 1f));
    }
}

using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Generation params")]
    [Range(0, 90)]
    [SerializeField] private float _angle;
    [Min(0)]
    [SerializeField] private float _min;
    [Min(0)]
    [SerializeField] private float _max;
    [Min(0)]
    [SerializeField] private float _height;

    [Header("Prefabs")]
    [SerializeField] private List<Element> _elements;
    [SerializeField] private GameObject _checkpointPrefab;
    [SerializeField] private GameObject _coinPrefab;

    [Header("Start elements")]
    [SerializeField] private GameObject _startElements;

    private List<GameObject> _lastSpawned = new List<GameObject>();
    private Queue<GameObject> _checkpoints = new Queue<GameObject>();
    private INextPointGenerator _nextPointGenerator;

    void Start()
    {
        _nextPointGenerator = new AngleNextPointGenerator(_angle);
        GenerateLevelPart(Vector3.zero);
        AddStartElements(_startElements);
    }

    private void AddStartElements(GameObject startElements)
    {
        _lastSpawned.Add(startElements);
    }

    public void GenerateLevelPart(Vector3 start)
    {
        DeleteLastElements();
        SpawnCoin(start);

        var nextPosition = start;
        while (nextPosition.y < start.y + _height)
        {
            var distance = Random.Range(_min, _max);
            nextPosition = _nextPointGenerator.Get(nextPosition, distance);
            var element = _elements[Random.Range(0,_elements.Count)];
            _lastSpawned.Add(Instantiate(element.Wall, nextPosition + element.Start, Quaternion.identity));
            nextPosition += element.End;
        }
        nextPosition = _nextPointGenerator.Get(nextPosition, Random.Range(_min, _max));
        _checkpoints.Enqueue(Instantiate(_checkpointPrefab, nextPosition, Quaternion.identity));
    }

    private void DeleteLastElements()
    {
        if(_checkpoints.Count > 1)
            Destroy(_checkpoints.Dequeue());

        foreach (var element in _lastSpawned)
            Destroy(element);
        _lastSpawned.Clear();
    }

    private void SpawnCoin(Vector3 position)
    {
        var randX = Random.Range(-_max, _max);
        var randY = Random.Range(0, _height);
        var offset = new Vector3(randX, randY, 0f);
        _lastSpawned.Add(Instantiate(_coinPrefab, position + offset, Quaternion.identity));
    }
}

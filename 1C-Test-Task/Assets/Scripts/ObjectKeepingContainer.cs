using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectKeepingContainer : MonoBehaviour
{
    [SerializeField] private List<ObjectDetector> _objectsList;

    [SerializeField] private RandomDirectionGenerator _randomDirectionGenerator;

    [SerializeField] private BoundsChecker _boundsChecker;

    [SerializeField] private SpawnManager _spawnManager;

    public List<ObjectDetector> ObjectsList => _objectsList;

    private void OnEnable()
    {
        _spawnManager.OnObjectSpawned += OnEventObjectSpawned;
    }

    private void OnDisable()
    {
        _spawnManager.OnObjectSpawned -= OnEventObjectSpawned;
    }

    private void Awake()
    {
        _objectsList = FindObjectsOfType<ObjectDetector>().ToList();

        foreach (ObjectDetector obj in _objectsList)
        {
            AssignComponents(obj);
        }
    }

    private void OnEventObjectSpawned(ObjectDetector objectDetector)
    {
        AssignComponents(objectDetector);
        _objectsList.Add(objectDetector);
    }

    private void AssignComponents(ObjectDetector obj)
    {
        obj.GetObjectContainer(this);
        var objMover = obj.GetComponent<ObjectMover>();
        objMover.AssignAdditionalComponents(_randomDirectionGenerator, _boundsChecker);
    }
}

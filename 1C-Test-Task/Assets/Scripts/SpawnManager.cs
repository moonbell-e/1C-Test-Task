using System;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public event Action<ObjectDetector> OnObjectSpawned;

    [SerializeField] private GameObject _prefab;

    public void SpawnNewObject()
    {
        GameObject obj = Instantiate(_prefab, new Vector3(0, 0, 0), Quaternion.identity);
        var objectDetector = obj.GetComponent<ObjectDetector>();
        OnObjectSpawned?.Invoke(objectDetector);
    }
}

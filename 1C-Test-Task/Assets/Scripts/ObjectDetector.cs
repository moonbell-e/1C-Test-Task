using System;
using UnityEngine;

[RequireComponent(typeof(ObjectMover))]
public class ObjectDetector : MonoBehaviour
{
    public event Action OnObjectDetected;
    public event Action OnObjectLost;

    [Range(0f, 360f)]
    [SerializeField] private float _detectionAngle;

    [SerializeField] private float _detectionRadius;

    [SerializeField] private ObjectMover _objectMover;

    [SerializeField] private ObjectKeepingContainer _container;

    private float _objectDistance;
    private float _angleForCheck;

    private Vector3 _detectionEnd;
    private Vector3 _secondDetectionEnd;


    private void Start()
    {
        _angleForCheck = _detectionAngle / 2;
    }

    private void Update()
    {
        foreach (ObjectDetector objectT in _container.ObjectsList)
        {
            if (objectT.transform != transform)
            {
                _objectDistance = Vector3.Distance(transform.position, objectT.transform.position);

                if (_objectDistance <= _detectionRadius)
                {
                    float angle = CalculateAngle(objectT.transform.position);
                    bool _isDetected = angle <= _angleForCheck;

                    (_isDetected ? OnObjectDetected : OnObjectLost)?.Invoke();
                }
            }
        }
    }

    public void GetObjectContainer(ObjectKeepingContainer container)
    {
        _container = container;
    }

    private float CalculateAngle(Vector3 objectPosition)
    {
        var vectorBetweenObjects = objectPosition - transform.position;
        return Vector3.Angle(vectorBetweenObjects, _objectMover.MoveDirection);
    }

    private void OnDrawGizmos()
    {
        Vector3 detectionEnd = transform.position + Quaternion.Euler(0f, 0f, _detectionAngle * 0.5f) * _objectMover.MoveDirection * _detectionRadius;
        Vector3 detectionEnd2 = transform.position + Quaternion.Euler(0f, 0f, -_detectionAngle * 0.5f) * _objectMover.MoveDirection * _detectionRadius;

        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, detectionEnd);
        Gizmos.DrawLine(transform.position, detectionEnd2);
    }
}

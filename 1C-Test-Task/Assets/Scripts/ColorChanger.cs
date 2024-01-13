using UnityEngine;

[RequireComponent(typeof(ObjectDetector))]
public class ColorChanger : MonoBehaviour
{
    [SerializeField] private ObjectDetector _objectDetector;
    [SerializeField] private Color _standardColor;
    [SerializeField] private Color _detectionColor;

    private SpriteRenderer _sprite;

    private void OnEnable()
    {
        _objectDetector.OnObjectDetected += OnEventObjectDetected;
        _objectDetector.OnObjectLost += OnEventObjectLost;
    }

    private void OnDisable()
    {
        _objectDetector.OnObjectDetected -= OnEventObjectDetected;
        _objectDetector.OnObjectLost -= OnEventObjectLost;
    }

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.color = _standardColor;

    }

    public void OnEventObjectDetected()
    {
        _sprite.color = _detectionColor;
    }

    public void OnEventObjectLost()
    {
        _sprite.color = _standardColor;
    }
}

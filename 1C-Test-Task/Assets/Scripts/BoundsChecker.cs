using UnityEngine;

public class BoundsChecker : MonoBehaviour
{
    [SerializeField] private GameFieldBoundsHandler _gameField;

    private float _xLeft;
    private float _xRight;
    private float _yTop;
    private float _yBottom;

    private void Start()
    {
        _gameField.SetBoundsValues(out _xLeft, out _xRight, out _yTop, out _yBottom);
    }

    public Border GetBoundsCondition(float currentX, float currentY, float radius)
    {
        if (currentX <= _xLeft + radius) return Border.Left;
        if (currentX >= _xRight - radius) return Border.Right;
        if (currentY >= _yTop - radius) return Border.Top;
        if (currentY <= _yBottom + radius) return Border.Bottom;

        return Border.None;
    }
}

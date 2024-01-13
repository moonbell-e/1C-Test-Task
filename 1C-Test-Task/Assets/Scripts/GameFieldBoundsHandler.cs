using UnityEngine;

public class GameFieldBoundsHandler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _gameFieldRenderer;

    public void SetBoundsValues(out float xLeft, out float xRight, out float yTop, out float yBottom)
    {
        xLeft = _gameFieldRenderer.bounds.min.x;
        xRight = _gameFieldRenderer.bounds.max.x;
        yTop = _gameFieldRenderer.bounds.max.y;
        yBottom = _gameFieldRenderer.bounds.min.y;
    }
}

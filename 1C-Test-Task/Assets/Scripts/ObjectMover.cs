using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [Range(3f, 10f)]
    [SerializeField] private float _moveSpeed;

    private RandomDirectionGenerator _randomDirectionGenerator;
    private BoundsChecker _boundsChecker;

    private Vector3 _moveDirection;
    private Transform _transform;

    private float _raduis;

    public Vector3 MoveDirection => _moveDirection;

    private void Awake()
    {
        _transform = transform;
        _raduis = GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    private void Start()
    {
        SetFirstDirection();
    }

    private void Update()
    {
        MoveObject();
    }

    public void AssignAdditionalComponents(RandomDirectionGenerator randomDirectionGenerator, BoundsChecker boundsChecker)
    {
        _randomDirectionGenerator = randomDirectionGenerator;
        _boundsChecker = boundsChecker;
    }

    private void MoveObject()
    {
        _transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime);
        Border border = _boundsChecker.GetBoundsCondition(_transform.position.x, _transform.position.y, _raduis);

        if (border != Border.None)
            _moveDirection = _randomDirectionGenerator.GetRandomDirection(border);
    }

    private void SetFirstDirection()
    {
        _moveDirection = _randomDirectionGenerator.GetRandomDirection((Border)Random.Range(0, 3));
    }
}

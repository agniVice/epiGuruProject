using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;

    [Range(0f, 1f)] [SerializeField] private float _sensetivity = 0.3f;

    private float _xPos;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        if(GameState.Instance.CurrentState == State.InGame)
            ReadMove();
    }
    private void ReadMove()
    {
        if (Input.touchCount >= 1)
        {
            Touch touch = Input.GetTouch(0);

            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                return;

            float halfScreen = Screen.width / 2;
            float xPos = (touch.position.x - halfScreen) / (halfScreen * _sensetivity);

            _xPos = Mathf.Clamp(xPos, _minX, _maxX);
            Move(_xPos);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _xPos -= Time.deltaTime * 3;
            _xPos = Mathf.Clamp( _xPos, _minX, _maxX );
            Move(_xPos);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _xPos += Time.deltaTime * 3;
            _xPos = Mathf.Clamp(_xPos, _minX, _maxX);
            Move(_xPos);
        }
    }
    public void Disable() => _rigidbody.constraints = RigidbodyConstraints.None;
    private void Move(float x) => _rigidbody.MovePosition(new Vector3(x, transform.localPosition.y, transform.localPosition.z));
}

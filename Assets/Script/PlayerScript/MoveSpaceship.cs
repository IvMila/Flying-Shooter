using UnityEngine;
using UnityEngine.EventSystems;

public class MoveSpaceship : MonoBehaviour
{
    private float _speed = 200;
    [HideInInspector] public Rigidbody2D Rigidbody;
    private Vector2 _lastPoint;
    private Vector2 _point;
    private int _multiplier = 1000;

    private Vector3 _velocity;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float xClamp = Mathf.Clamp(transform.position.x, -7.5f, 7.5f);
        float yClamp = Mathf.Clamp(transform.position.y, -2.5f, 2.5f);
        transform.position = new Vector2(xClamp, yClamp);

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lastPoint = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                _point = Input.mousePosition;
                Vector2 delta = (_point - _lastPoint) / Screen.width * _multiplier;

                _lastPoint = _point;

                var velocity = Rigidbody.velocity;

                velocity.x = delta.x * _speed * Time.deltaTime;
                velocity.y = delta.y * _speed * Time.deltaTime;
                _velocity = velocity;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _velocity = Vector3.zero;
            }
        }
        else
        {
            _velocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        Rigidbody.velocity = _velocity;
    }

    //private float _dirX, _dirY;
    //private float _speed = 5f;
    //public Joystick Joystick;

    //private Rigidbody2D _rigidbody2D;

    //private void Start()
    //{
    //    _rigidbody2D = GetComponent<Rigidbody2D>();
    //}

    //private void Update()
    //{
    //    _dirX = Joystick.Horizontal * _speed;
    //    _dirY = Joystick.Vertical * _speed;
    //}

    //private void FixedUpdate()
    //{
    //    _rigidbody2D.velocity = new Vector2(_dirX, _dirY);
    //}
}

using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private string _obstacleTag;

    [Range(30, 100)][SerializeField] private float _minSpeed;
    [Range(100, 360)][SerializeField] private float _maxSpeed;

    private float _rotationSpeed;

    private void Start()
    {
        _rotationSpeed = Random.Range(_minSpeed, _maxSpeed);
    }
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, Time.fixedDeltaTime*_rotationSpeed, 0f));
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(_obstacleTag))
            Destroy(gameObject);
    }
}

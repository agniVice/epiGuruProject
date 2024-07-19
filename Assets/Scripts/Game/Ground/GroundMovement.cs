using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    private float _groundSpeed;

    private void FixedUpdate()
    {
        if (GameState.Instance.CurrentState != State.Paused && GameState.Instance.CurrentState != State.Ready)
            transform.position += Vector3.back * Time.fixedDeltaTime * _groundSpeed;
        if (GameState.Instance.CurrentState == State.Finished)
            _groundSpeed *= 0.995f;
    }
    public void SetSpeed(float speed) => _groundSpeed = speed;
}

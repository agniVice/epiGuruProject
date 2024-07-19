using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    [SerializeField] private string _playerTag = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_playerTag))
        {
            if (GameState.Instance.CurrentState == State.Finished)
                return;

            GroundSpawner.Instance.SpawnGround();
            GroundSpawner.Instance.DestroyLastGround();
        }
    }
}

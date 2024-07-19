using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [Header("Tags")]
    [SerializeField] private string _coinTag;
    [SerializeField] private string _obstacleTag;

    private PlayerMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_coinTag))
        {
            if (GameState.Instance.CurrentState != State.InGame)
                return;

            UserBalance.Instance.AddScore(this, 1);
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(_obstacleTag))
            PlayerGameOver();
    }
    public void PlayerGameOver()
    {
        _movement.Disable();
        GameState.Instance.FinishGame();
    }
}
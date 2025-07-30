using UnityEngine;

public class Player : MonoBehaviour
{
    private EntityHealth _playerHealth;

    private void OnEnable()
    {
        _playerHealth = GetComponent<EntityHealth>();
        _playerHealth.OnDeath += HandleDeath;
    }

    private void OnDisable()
    {
        _playerHealth.OnDeath -= HandleDeath;
    }

    private void HandleDeath()
    {
        GameManager.Instance.GameOver();
    }
}

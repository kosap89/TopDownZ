using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] float _dps; // Damage Per Second

    void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        if (collision.gameObject.TryGetComponent(out EntityHealth entityHealth))
        {
            entityHealth.LoseHealth(Time.fixedDeltaTime * _dps);
        }
    }
}


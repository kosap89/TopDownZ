using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [SerializeField] AudioClip _deathSound;
    EntityHealth _entityHealth;
    NavMeshAgent _agent;
    GameObject _target;

    private void Awake()
    {
        _entityHealth = GetComponent<EntityHealth>();
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
    }

    public void DestroyEnemy()
    {
        AudioManager.Instance.PlayAudio(_deathSound, AudioManager.SoundType.SFX, 1.0f, false);
        Destroy(gameObject);
    }

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _entityHealth.OnDeath += DestroyEnemy;
    }

    private void OnDisable()
    {
        _entityHealth.OnDeath -= DestroyEnemy;
    }

    private void Update()
    {
        _agent.SetDestination(_target.transform.position);
    }

}

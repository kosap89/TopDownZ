using UnityEngine;

public class PlayerStaffController : MonoBehaviour
{
    [SerializeField] AudioClip _shootSound;
    [SerializeField] Projectile _projectile;
    [SerializeField] Transform _tip;
    [SerializeField] float _fireRate;
    [SerializeField] private float _alternateAttackCooldown = 10f;
    private float _lastAlternateAttackTime = -Mathf.Infinity;

    [SerializeField] private int _projectilesInCircle = 8;

    float _nextFireTime;

    Vector2 _lookDirection;

    void Update()
    {
        SetLookDirection();
        RotateStaff();

        // Vasen nappi = normaali hyökkäys (Fire1 oletuksena vasen hiiri tai Ctrl)
        if (Input.GetButton("Fire1") && Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + 1f / _fireRate;
            Shoot();
        }

        // Oikea nappi = erikoishyökkäys, cooldownilla
        if (Input.GetButtonDown("Fire2") && Time.time >= _lastAlternateAttackTime + _alternateAttackCooldown)
        {
            AlternateAttack();
        }
    }


    void RotateStaff()
    {
        float angle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Shoot()
    {
        AudioManager.Instance.PlayAudio(_shootSound, AudioManager.SoundType.SFX, 0.4f, false);
        Projectile newProjectile = Instantiate(_projectile, _tip.position, Quaternion.identity);
        newProjectile.InitializeProjectile(_lookDirection);
    }


    void SetLookDirection()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _lookDirection = (mousePosition - (Vector2)transform.position).normalized;
    }
    void AlternateAttack()
    {
        _lastAlternateAttackTime = Time.time;

        float angleStep = 360f / _projectilesInCircle;
        float angle = 0f;

        for (int i = 0; i < _projectilesInCircle; i++)
        {
            float projectileDirX = Mathf.Cos(angle * Mathf.Deg2Rad);
            float projectileDirY = Mathf.Sin(angle * Mathf.Deg2Rad);

            Vector2 direction = new Vector2(projectileDirX, projectileDirY).normalized;

            Projectile newProjectile = Instantiate(_projectile, _tip.position, Quaternion.identity);
            newProjectile.InitializeProjectile(direction);

            angle += angleStep;
        }

        // Käytetään samaa ääntä kuin Shoot():ssa
        AudioManager.Instance.PlayAudio(_shootSound, AudioManager.SoundType.SFX, 0.4f, false);
    }



}


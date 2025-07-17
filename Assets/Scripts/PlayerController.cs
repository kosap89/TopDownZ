using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _movementSpeed;
    [SerializeField] SpriteRenderer _characterBody;
    [SerializeField] Animator _animator;
    [SerializeField] AudioClip _footstep;
    Rigidbody2D _rb;
    float _nextFootstepAudio = 0f;

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        movement = Vector2.ClampMagnitude(movement, 1.0f);
        _rb.linearVelocity = movement * _movementSpeed;

        bool characterIsWalking = movement.magnitude > 0f;
        _animator.SetBool("isWalking", characterIsWalking);

        if (characterIsWalking)
        {
            HandleWalkingSounds();

        }
        bool flipSprite = movement.x < 0f;
        _characterBody.flipX = flipSprite;
    }
    
    void HandleWalkingSounds()
        {
            if (Time.time >= _nextFootstepAudio)
            {
                AudioManager.Instance.PlayAudio(_footstep, AudioManager.SoundType.SFX, 1f, false);

                float audioFrequency = _animator.GetCurrentAnimatorClipInfo(0)[0].clip.length / 2f;
                _nextFootstepAudio = Time.time + audioFrequency;
            }
        }


        
}


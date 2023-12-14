using UnityEngine;

public class CharacterController : MonoBehaviour, IPlayAnimation
{
    private Animator _animator;
    private bool _isWalking;

    private const float walk_speed = 10f; 
    private const string walk_animation_name = "Walk";
    private const string idle_animation_name = "Idle";
    private const float finish_pos_x = 25f;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_isWalking) return;

        transform.Translate(Vector2.right * walk_speed * Time.deltaTime);


        if (transform.position.x > finish_pos_x)
        {
            _isWalking = false;
            _animator.Play(idle_animation_name); 
        }
    }

    public void Play()
    {
        _animator.Play(walk_animation_name);
        _isWalking = true;
    }
}

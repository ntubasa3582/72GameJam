using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    static int hashSpeed = Animator.StringToHash("Speed");
    static int hashFallSpeed = Animator.StringToHash("FallSpeed");
    static int hashGroundDistance = Animator.StringToHash("GroundDistance");
    static int hashIsCrouch = Animator.StringToHash("IsCrouch");

    static int hashDamage = Animator.StringToHash("Damage");

    [SerializeField] private float characterHeightOffset = 0.2f;
    [SerializeField] LayerMask groundMask;

    [SerializeField, HideInInspector] Animator _animator;
    [SerializeField, HideInInspector] SpriteRenderer _spriteRenderer;

    [SerializeField] private GameObject bullet = null;       //�v���C���[�̔��˂���e
    Rigidbody2D _rigidbody = null;

    public int _direction = 1;         //���˂�������, 1�̎��E�ɁA-1�̂Ƃ����ɒe�����

    [SerializeField] private float _movespeed_x = 5.0f;     //�ړ����x

    [SerializeField] private float _jumppower = 10.0f;        //�W�����v��

    [SerializeField] private float _bullet_interval = 1.0f;     //�e�̔��ˊԊu
    private float _bullet_interval_count = 0;

    [SerializeField] private float _jump_count_max = 1;        //�W�����v��
    private float _jump_count = 0;      //�W�����v�񐔂̃J�E���g

    enum Direction
    {
        RIGHT = 1,          // �E����
        LEFT = -1           // ������
    };


    private void Start()
    {
        _direction = (int)Direction.RIGHT;
        _animator = GetComponent<Animator>();                //�A�j���[�^�[�̎擾
        _spriteRenderer = GetComponent<SpriteRenderer>();    //�X�v���C�g�����_���[�̎擾
        _rigidbody = GetComponent<Rigidbody2D>();           //���W�b�g�{�f�B�̎擾
    }


    void move()
    {
        float axis = Input.GetAxis("Horizontal");      //���̈ړ�
        bool isDown = Input.GetAxisRaw("Vertical") < 0;

        //�����Ă���������擾
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && _direction == (int)Direction.RIGHT)
        {
            _direction = (int)Direction.LEFT;
        }
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && _direction == (int)Direction.LEFT)
        {
            _direction = (int)Direction.RIGHT;
        }


        Vector2 move = _rigidbody.velocity;
        //_rigidbody.velocity = move;

        if (Input.GetButtonDown("Jump") && _jump_count < _jump_count_max)
        {
            _jump_count++;

            move.y = _jumppower;

            _animator.SetTrigger("JumpTrigger");
            _animator.SetBool("Ground", false);

            //Vector2 jump = new Vector2(0, _jumppower);
            //_rigidbody.AddForce(jump, ForceMode2D.Impulse);
        }

        if (axis != 0)
        {
            _spriteRenderer.flipX = axis < 0;
            move.x = axis * _movespeed_x;
        }
        _rigidbody.velocity = move;

        var distanceFromGround = Physics2D.Raycast(transform.position, Vector3.down, 1, groundMask);

        // update animator parameters
        _animator.SetBool(hashIsCrouch, isDown);
        _animator.SetFloat(hashGroundDistance, distanceFromGround.distance == 0 ? 99 : distanceFromGround.distance - characterHeightOffset);
        _animator.SetFloat(hashFallSpeed, _rigidbody.velocity.y);
        _animator.SetFloat(hashSpeed, Mathf.Abs(axis));
    }

    void Bullet()
    {
        if (Input.GetMouseButton(0) && _bullet_interval_count <= 0)
        {
            Vector3 spawn_pos = transform.position + new Vector3(3 * _direction, 0, 0);

            var b = Instantiate(bullet, spawn_pos, transform.rotation);
            b.GetComponent<bullet>().SetDir(_direction);

            _bullet_interval_count = _bullet_interval;
        }

        if (_bullet_interval_count > 0)
        {
            _bullet_interval_count -= Time.deltaTime;
        }

    }

    void Update()
    {
        move();
        Bullet();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grond"))
        {

            _animator.SetBool("Ground", true);
            
            _jump_count = 0;

        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            _animator.SetTrigger(hashDamage);
        }


    }
}
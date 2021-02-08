using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioController))]
public class Character2DController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 15f;
    public static Character2DController _instance;

    private Rigidbody2D _rigidbody;
    private AudioController _audioController;
    private IInteractable _interactable;

    private float _movement;
    private bool _jumped = false;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        _rigidbody = GetComponentInParent<Rigidbody2D>();
        _audioController = GetComponentInParent<AudioController>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        _movement = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _jumped = true;
        }

        if (Input.GetKey(KeyCode.E))
        {
            if(_interactable != null)
            {
                _interactable.Interact();
            }
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(_movement, 0, 0) * Time.fixedDeltaTime * movementSpeed;

        if (_jumped)
        {
            _rigidbody.velocity = Vector2.up * jumpForce;
            _jumped = false;
            //_audioController.PlayJump();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<IInteractable>() != null)
        {
            _interactable = collision.gameObject.GetComponent<IInteractable>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _interactable = null;
    }
}

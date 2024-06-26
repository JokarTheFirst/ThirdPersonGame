using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using static UnityEngine.ParticleSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float multiplier;
    public float acceleration;
    public Animator playerAnimator;

    [HideInInspector] public bool isSprinting;
    [HideInInspector] public float currentSpeed;

    #region Variables: Controller

    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;

    #endregion
    #region Variables: Movement

    [SerializeField] private Movement movement;
    [SerializeField] private float smoothTime = 0.05f;
    private bool doParticle = true;
    private float _currentVelocity;
    
    #endregion
    #region Variables: Particles

    [SerializeField] public GameObject _sprintParticle;
    [SerializeField] public GameObject particlePosition;
    [SerializeField] private float _particleDuration = 0.05f;

    #endregion
    #region Variables: Gravity

    private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float _velocity;

    #endregion
    #region Variables: Jumping

    [SerializeField] private float jumpPower;
    private int _numberOfJumps;
    [SerializeField] private int maxNumberOfJumps = 2;

    #endregion

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_input == Vector2.zero)
        {
            playerAnimator.SetFloat("Vertical", 0);
        }
        else if (!isSprinting)
        {
            playerAnimator.SetFloat("Vertical", 1);
            
        }
        
        if (doParticle && isSprinting )
        {
            playerAnimator.SetFloat("Vertical", 2);
            StartCoroutine(SpawnParticle());
            
        }
        ApplyGravity();
        ApplyRotation();
        ApplyMovement();
        
    }
   

    private void ApplyRotation()
    {
        if (_input.sqrMagnitude == 0) return;

        var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    private void ApplyMovement()
    {
        var targetSpeed = isSprinting ? speed * multiplier : speed;
        
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);

        _characterController.Move(_direction * currentSpeed * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        if (IsGrounded() && _velocity < 0)  _velocity = -1.0f;
        
        else _velocity += _gravity * gravityMultiplier * Time.deltaTime;
        
        _direction.y = _velocity;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsGrounded() && _numberOfJumps >= maxNumberOfJumps) return;
        if (_numberOfJumps == 0) StartCoroutine(WaitForLanding());

        _numberOfJumps++;
        _velocity = jumpPower;
    }
    public void Sprint(InputAction.CallbackContext context)
    {
        isSprinting = context.started || context.performed;
    }

    private IEnumerator WaitForLanding()
    {
        yield return new WaitUntil(() => !IsGrounded());
        yield return new WaitUntil(IsGrounded);

        _numberOfJumps = 0;
    }

    private bool IsGrounded() => _characterController.isGrounded;

    IEnumerator SpawnParticle()
    {
        doParticle = false;
        Instantiate(_sprintParticle, particlePosition.transform.position, particlePosition.transform.rotation);
        
        yield return new WaitForSeconds(_particleDuration);
        doParticle = true;
    }
   
}

[Serializable]
public struct Movement
{
    
}

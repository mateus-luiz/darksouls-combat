using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 _inputs;
    
    public CharacterController playerController;

    #region Movement
    [SerializeField]
    private float _currentVelocity;
    public float walkVelocity = 6f;
    public float maxVelocity = 12f;
    private float currentTimeVelocity;
    private float smoothTime = 0.1f;
    public float gravity = -12.5f;
    #endregion

    public void Start(){

        _currentVelocity = walkVelocity;
    }

    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        _inputs = new Vector3(horizontal, _inputs.y, vertical).normalized;

        if(_currentVelocity >= maxVelocity){
            _currentVelocity = maxVelocity;
        }

        if(_currentVelocity <= walkVelocity)
        {
            _currentVelocity = walkVelocity;
        }
    }

    private void FixedUpdate()
    {
        Vector3 direction = _inputs * _currentVelocity  * Time.deltaTime;
        direction.y += gravity * Time.deltaTime;

        if(playerController.isGrounded && direction.y < 0)
        {
            gravity = -9.0f;
        }

        if(direction.magnitude >= 0.1f)
        {
            if(Running())
            {
                _currentVelocity += 1 * Time.deltaTime;
            }
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float smoothRot = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentTimeVelocity, smoothTime);
            
            transform.rotation = Quaternion.Euler(0f, smoothRot, 0f);
            playerController.Move(direction);
        }

        
        
        if(!Running())
        {
            _currentVelocity = walkVelocity;
        }
    }

    private bool Running()
    {
        if(Input.GetButton("Run"))
        {
            return true;
        }

        return false;
    }
}

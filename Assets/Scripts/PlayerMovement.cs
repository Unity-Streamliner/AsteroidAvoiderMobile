using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maxVelocity;

    private Vector3 _movementDirection;
    private Camera mainCamera;
    private Rigidbody _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Touch.activeTouches.Count == 0)
        {
            _movementDirection = Vector3.zero;
            return;
        }

        Vector2 touchPosition = Touch.activeTouches[0].screenPosition;
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

        _movementDirection = transform.position - worldPosition;
        _movementDirection.z = 0f;
        _movementDirection.Normalize();
    }

    private void FixedUpdate()
    {
        if (_movementDirection == Vector3.zero)
        {
            return;
        }
        _rigidbody.AddForce(_movementDirection * forceMagnitude, ForceMode.Force);
        _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, maxVelocity);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Cannon: MonoBehaviour
{
    [SerializeField] float _shootForce;
    Collider2D _collider;
    [SerializeField] protected Transform _shootingPoint;
    [SerializeField] protected float _targetAngle;
    [SerializeField] protected float _originalAngle;
    [SerializeField] protected float _rotationSpeed;
    [SerializeField] public bool _isRotating;
    protected Transform _parentTransform;
    [SerializeField] bool _resetToOgPosition;

    

    public float ShootForce
    {
        get
        {
            return _shootForce;
        }
    }

    public Transform ShootingPoint
    {
        get
        {
            return _shootingPoint;
        }
    }
    public Action finishRotation;

    public abstract void Rotate();



    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _isRotating = false;
        _parentTransform = transform.parent != null ? transform.parent : transform;
        
    }

    private void Start()
    {
        _originalAngle = _parentTransform.eulerAngles.z;
    }

    public void RotateToTarget(float targetAngle)
    {
        float currentAngle = _parentTransform.eulerAngles.z;
        float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, _rotationSpeed * Time.deltaTime);
        _parentTransform.eulerAngles = new Vector3(0f, 0f, newAngle);

        if (Mathf.Abs(Mathf.DeltaAngle(currentAngle, targetAngle)) < 0.1f)
        {
            _parentTransform.eulerAngles = new Vector3(0f, 0f, targetAngle);
            FinishRotation();
        }
    }

    protected void FinishRotation()
    {
        _isRotating = false;

    }

    public void initiateRotation()
    {
        _isRotating = true;
    }

    


}


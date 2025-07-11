using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    Rigidbody2D _rb;
    Cannon _currentCannon;
    ShootController _shootController;
    Transform _shootingPoint;
    float _shootForce;
    SpriteRenderer _PlayerSprite;
    bool _isFlying;
    private HashSet<Cannon> cannonsTouched = new HashSet<Cannon>();

    [SerializeField] GameObject _explosion;

    AudioManager audioManager;


    private void Awake()
    {
       //  AudioManager.Instance.PlaySFX(AudioManager.Instance.Disparo);
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _shootController = GetComponent<ShootController>();
        _PlayerSprite = GetComponentInChildren<SpriteRenderer>();
        _isFlying = true;

        cannonsTouched.Clear();
    }


    void Update()
    {
        if((_currentCannon!=null) && (_currentCannon._isRotating))
        {
            if (!_isFlying)
            {
                PositionInShootingPoint(_currentCannon.ShootingPoint);
            }
        }
    }

    public void FreezeMovement()
    {
        _rb.isKinematic = true;
        _rb.velocity = Vector2.zero;
    }

    public void PositionInShootingPoint(Transform shootingPoint)
    {
        transform.position = shootingPoint.position;
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cannon cannon = collision.GetComponent<Cannon>();
        if (cannon && !cannonsTouched.Contains(cannon))
        {
            Debug.Log("Toqu� un nuevo ca��n: " + cannon.name);
            cannonsTouched.Add(cannon);

            if (GameManager.Instance != null)
            {
                GameManager.Instance.CannonHit();
            }
            else
            {
               // Debug.LogError("GameManager.Instance es null");
            }


        }

        if (collision.GetComponent<Cannon>() != null)
        {
            _isFlying = false;
            HidePlayer();
            _currentCannon = cannon;
            _currentCannon.initiateRotation();
            _currentCannon._isCurrentCannon = true;

            _shootingPoint = _currentCannon.ShootingPoint;
            _shootForce = _currentCannon.ShootForce;

            PositionInShootingPoint(_currentCannon.ShootingPoint);
            FreezeMovement();
        }
        

    }


    public void Shoot()
    {
        if (!_isFlying)
        {
            _rb.isKinematic = false;
            _isFlying = true;
            ShowPlayer();
            _rb.AddForce(_shootingPoint.right * _shootForce, ForceMode2D.Impulse);
            SpawnExplosion(_explosion); //Feedback visual....quiza conviene pasarlo al script de Cannon????
            AudioManager.Instance.PlaySFX(AudioManager.Instance.Disparo);
            _currentCannon._isRotating = false;
            _currentCannon._isCurrentCannon = false;
        }
    }

    private void SpawnExplosion(GameObject gameObject)
    {
        Instantiate(gameObject, transform.position, transform.rotation);
    }


    void HidePlayer()
    {
        _PlayerSprite.enabled = false;
    }

    void ShowPlayer()
    {
        _PlayerSprite.enabled = true;
    }

}

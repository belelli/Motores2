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


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _shootController = GetComponent<ShootController>();
        _PlayerSprite = GetComponentInChildren<SpriteRenderer>();
        _isFlying = true;
    }



    // Update is called once per frame
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

        if (collision.GetComponent<Cannon>())
        {
            Debug.Log("toque cannon");
            _isFlying = false;
            HidePlayer();
            _currentCannon = collision.GetComponent<Cannon>();
            _currentCannon.initiateRotation();


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
            Debug.Log("Player is shot");
            _currentCannon._isRotating = false;
        }


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

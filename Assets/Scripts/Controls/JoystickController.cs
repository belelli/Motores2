using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Vector2 _initialPosition;
    [SerializeField] float _magnitude = 100;
    Vector2 _moveDir;


    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  Vector3 GetRotationInput()
    {
        return _moveDir;
    }

    public float GetAngle()
    {
        float angleRad = Mathf.Atan2(_moveDir.y, _moveDir.x);
        float angleDeg = angleRad * Mathf.Rad2Deg;
        return angleDeg;
    }


    public void OnDrag(PointerEventData eventData)
    {
        _moveDir = Vector2.ClampMagnitude(eventData.position - _initialPosition, _magnitude);
        transform.position = _initialPosition + _moveDir;
        //Debug.Log("angulo" + GetAngle());
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _moveDir = Vector2.zero;
        transform.position = _initialPosition;
    }
}

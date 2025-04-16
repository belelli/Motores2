using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCannon : Cannon
{


    // Start is called before the first frame update
    void Start()
    {
        _targetAngle = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_isRotating == true)
        {
            Debug.Log("aca???");
            Rotate();
        }
    }

    public override void Rotate()
    {
        Debug.Log("what happenb");
        _parentTransform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
    }
}

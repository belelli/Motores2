using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualCannon : Cannon
{
    [SerializeField] JoystickController _controller;
    public override void Rotate()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<JoystickController>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation.z = _controller.GetAngle();
    }
}

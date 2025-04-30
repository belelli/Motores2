using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualCannon : Cannon
{
    [SerializeField] JoystickController _controller;
    public override void Rotate()
    {
        _parentTransform.eulerAngles = new Vector3(0f, 0f, _controller.GetAngle());
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation.z = _controller.GetAngle();
        if (_isCurrentCannon) { Rotate(); }
        
    }

    public void FollowStick()
    {
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private MobileJoystick joystick;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private Transform cannonPivot;

    private bool canControl = false;

    private void Update()
    {
        if (!canControl) return;

        
        float horizontal = joystick.Horizontal();
        float vertical = joystick.Vertical();

        if (horizontal != 0 || vertical != 0)
        {
            float angle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;
            cannonPivot.rotation = Quaternion.Lerp(cannonPivot.rotation,
                                                 Quaternion.Euler(0, 0, angle - 90),
                                                 rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canControl = true;
            joystick.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canControl = false;
            joystick.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private EnumInterfaceStates InterfaseState;
    private float MaxSpeed = 5f;
    [SerializeField]
    private float CurrentSpeed = 0f;
    [SerializeField]
    private float Angle = 0f;
    private float RotateSpeed = 0.1f;
    private Vector3 TargetVector; 
    [SerializeField] private Ship Ship;
    [SerializeField]
    private Rigidbody Rb;
    [SerializeField]
    private TextMeshPro Speed_text;
    [SerializeField]
    private TextMeshPro Angle_text;
    void Start()
    {
        InterfaseState = EnumInterfaceStates.OnShipControll;
        if(Ship) MaxSpeed = Ship.MaxSpeed;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)) // Переключение управления между кораблем и палубой
        {
            if (InterfaseState == EnumInterfaceStates.OnShipControll) InterfaseState = EnumInterfaceStates.OnDeckControll;
            else InterfaseState = EnumInterfaceStates.OnShipControll;
        }

        if(Input.GetKeyDown(KeyCode.W)) CurrentSpeed = Mathf.Clamp(++CurrentSpeed, 0, MaxSpeed);

        if(Input.GetKeyDown(KeyCode.S)) CurrentSpeed = Mathf.Clamp(--CurrentSpeed, 0, MaxSpeed);

        if (Input.GetKey(KeyCode.A)) Angle = Angle - 0.1f;

        if (Input.GetKey(KeyCode.D)) Angle = Angle + 0.1f;

        if (Angle != 0f)
        {
            ShipRotate(Angle);
        }

        Speed_text.text = $"Speed: {CurrentSpeed.ToString()}";
        Angle_text.text = $"Angle: {Angle}";
    }

    private void FixedUpdate()
    {
        if(CurrentSpeed != 0)
        {
            Rb.MovePosition(Rb.position + (transform.forward * CurrentSpeed) / 100);
        }
        
    }

    private void ShipRotate(float angle)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), RotateSpeed * Time.deltaTime);
        if(Angle > 0) {
            Angle = Angle - 0.5f * Time.deltaTime;
        }
        else if(Angle < 0)
        {
            Angle = Angle + 0.5f * Time.deltaTime;
        }
        else if(Angle == 0) { Angle = 0; }
        
    }

    //private void MoveShip(float speed)
    //{
    //    TargetVector = transform.position + transform.forward;
    //    transform.position = Vector3.MoveTowards(transform.position, TargetVector, speed);
    //}
}

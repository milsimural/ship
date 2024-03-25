using System.Collections;
using System.Collections.Generic;
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

        if (Input.GetKey(KeyCode.A)) --Angle;

        if (Input.GetKey(KeyCode.D)) ++Angle;

        if(Angle != 0f) ShipRotate(Angle);
    }

    private void FixedUpdate()
    {
        if(CurrentSpeed != 0)
        {
            Rb.MovePosition(Rb.position + (Vector3.forward * CurrentSpeed) / 100);
        }
        
    }

    private void ShipRotate(float angle)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), RotateSpeed * Time.deltaTime);
    }

    //private void MoveShip(float speed)
    //{
    //    TargetVector = transform.position + transform.forward;
    //    transform.position = Vector3.MoveTowards(transform.position, TargetVector, speed);
    //}
}

using System;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class MyRobotMovementControllerv : MonoBehaviour
{
    public GameObject robotGameObject;
    public Transform joint0;
    public Transform joint1;
    public Transform pinsa;


    public Transform pala1;
    public Transform pala2;
    public Transform pala3;

    public Transform grabVector;

    public float speed;
    public float rotationSpeed;

    public float grabSpeed;
    public float maxConstraintZ = 50f;
    public float minConstraintZ = -5f;

    private Vector2 currentDirection = Vector2.zero;

    private Vector2 currentRotationJoint0 = Vector2.zero;
    private Vector2 currentRotationJoint1 = Vector2.zero;
    private Vector2 currentRotationJoint2 = Vector2.zero;


    public bool isGrabbing = false;

    private Rigidbody rbRobot;

    private void Awake()
    {
        rbRobot = robotGameObject.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        InputSystem.OnMove += UpdateDirection;
        InputSystem.OnRotatePinsa += PinsaRotation;

        InputSystem.OnRotate += UpdateRotationJoint0;
        InputSystem.OnRotateJoint1 += UpdateRotationJoint1;

        InputSystem.OnGrab += UpdateIsGrabbing;

        InputSystem.OnResetRotation += ResetRotation;
    }

    private void PinsaRotation(Vector2 rotation)
    {
        float rotationX = -1 * rotation.y * rotationSpeed * Time.deltaTime;
        float rotationY = rotation.x * rotationSpeed * Time.deltaTime;

        currentRotationJoint2 = new Vector3(rotationX, rotationY, 0);
    }

    private void OnDisable()
    {
        InputSystem.OnMove -= UpdateDirection;

        InputSystem.OnResetRotation -= ResetRotation;

        InputSystem.OnRotate -= UpdateRotationJoint0;
        InputSystem.OnRotateJoint1 -= UpdateRotationJoint1;

        InputSystem.OnResetRotation -= ResetRotation;
    }

    private void UpdateDirection(Vector2 direction)
    {
        currentDirection = direction;
    }

    private void UpdateRotationJoint0(Vector2 rotation)
    {
        float rotationX = -1 * rotation.y * rotationSpeed * Time.deltaTime;
        float rotationY = rotation.x * rotationSpeed * Time.deltaTime;

        currentRotationJoint0 = new Vector3(rotationX, rotationY, 0);
    }
    private void UpdateRotationJoint1(Vector2 rotation)
    {
        float rotationX = rotation.y * rotationSpeed * Time.deltaTime;

        currentRotationJoint1 = new Vector3(rotationX, 0, 0);
    }
    private void UpdateIsGrabbing(bool value)
    {
        isGrabbing = value;
    }
    private void ResetRotation()
    {
        joint0.Rotate(Vector3.zero, Space.Self);
    }

    private void Update()
    {        
        if (currentDirection != Vector2.zero)
        {
            // Convert the Vector2 direction to a Vector3
            Vector3 movement = new Vector3(currentDirection.x, 0, currentDirection.y);

            // Move the robot using the speed and deltaTime for frame rate independence
            //robotGameObject.transform.Translate(movement * speed * Time.deltaTime, Space.World);
            rbRobot.AddForce(movement * speed * Time.deltaTime);
        }

        if (currentRotationJoint0.x != 0)
        {
            joint0.Rotate(currentRotationJoint0, Space.Self);
        }
        if (currentRotationJoint0.y != 0)
        {
            joint0.Rotate(currentRotationJoint0, Space.World);
        }
        if (currentRotationJoint1 != Vector2.zero)
        {
            joint1.Rotate(currentRotationJoint1, Space.Self);
        }

        if (currentRotationJoint2 != Vector2.zero)
        {
            pinsa.Rotate(currentRotationJoint2, Space.Self);
        }

        float pala1GlobalZ = NormalizeAngle(pala1.eulerAngles.z);

        if (isGrabbing) // Cerrar la pinza
        {
            if (pala1GlobalZ > minConstraintZ)
            {
                Vector3 rotationZ = new Vector3(0, 0, -1 * Time.deltaTime * grabSpeed);
                pala1.Rotate(rotationZ, Space.Self);
                pala2.Rotate(rotationZ, Space.Self);
                pala3.Rotate(rotationZ, Space.Self);
            }
        }
        else // Abrir la pinza
        {
            if (pala1GlobalZ < maxConstraintZ)
            {
                Vector3 rotationZ = new Vector3(0, 0, Time.deltaTime * grabSpeed);
                pala1.Rotate(rotationZ, Space.Self);
                pala2.Rotate(rotationZ, Space.Self);
                pala3.Rotate(rotationZ, Space.Self);
            }
        }
    }
    private float NormalizeAngle(float angle)
    {
        // Convierte el ángulo al rango -180° a 180°
        while (angle > 180f) angle -= 360f;
        while (angle < -180f) angle += 360f;
        return angle;
    }
}
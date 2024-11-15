using UnityEngine;

public class MyRobotMovementControllerv : MonoBehaviour
{
    public GameObject robotGameObject;
    public GameObject joint0;
    
    public float speed;
    public float rotationSpeed;
    private Vector2 currentDirection = Vector2.zero;
    private Vector2 currentRotation = Vector2.zero;

    private void OnEnable()
    {
        InputSystem.OnMove += UpdateDirection;
        InputSystem.OnRotate += UpdateRotation;
        InputSystem.OnResetRotation += ResetRotation;
    }
    private void OnDisable()
    {
        InputSystem.OnMove -= UpdateDirection;
        InputSystem.OnRotate -= UpdateRotation;
        InputSystem.OnResetRotation -= ResetRotation;
    }

    private void UpdateDirection(Vector2 direction)
    {
        currentDirection = direction;
    }
    
    private void UpdateRotation(Vector2 rotation)
    {
        float rotationX = rotation.y * rotationSpeed * Time.deltaTime;
        float rotationY = rotation.x * rotationSpeed * Time.deltaTime;
        currentRotation = new Vector3(rotationX, rotationY, 0);
    }
    private void ResetRotation()
    {
        joint0.transform.Rotate(Vector3.zero, Space.Self);
    }

    private void Update()
    {
        if (currentDirection != Vector2.zero)
        {
            // Convert the Vector2 direction to a Vector3
            Vector3 movement = new Vector3(currentDirection.x, 0, currentDirection.y);

            // Move the robot using the speed and deltaTime for frame rate independence
            robotGameObject.transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }

        if (currentRotation != Vector2.zero)
        {
            joint0.transform.Rotate(currentRotation, Space.Self);
        }
    }
}
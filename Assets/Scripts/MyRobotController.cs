using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyRobotController : MonoBehaviour
{
    public GameObject Stud_target;
    public Transform Workbench_destination;
    private MyRobotMovementControllerv _movementController;
    RaycastHit hit;
   
    public LayerMask hitLayerMask;
    public float distance = 2;
    private bool pickedTarget;

    /*
    This method will move the robot’s end effector to pick up Stud_target and then
    place it on the Workbench_destination.
    */

    private void Start()
    {
        _movementController = GetComponent<MyRobotMovementControllerv>();
        pickedTarget = false;
    }

    void PickStudAnim()
    {
        
        
    }
    
    /*
    This function builds on the previous exercise but aims to position
    Stud_target horizontally on the Workbench_destination.
    */
    void PickStudAnimVertical()
    {
        
    }

    private void Update()
    {
        Rigidbody rb = Stud_target.GetComponent<Rigidbody>();

        if (_movementController.isGrabbing)
        {
            if(RayCastToObject())
            {
                Stud_target.transform.parent = _movementController.pinsa;
                rb.isKinematic = true;
                pickedTarget=true;
            }
        }
        else if(!_movementController.isGrabbing && pickedTarget) 
        {
            Stud_target.transform.parent = null;
            rb.isKinematic = false;
        }
    }

    bool RayCastToObject()
    {
        Vector3 vectorToGrab = _movementController.grabVector.position - _movementController.pinsa.position;

        Debug.DrawRay(_movementController.pinsa.position, vectorToGrab * distance, color:Color.blue);
        return Physics.Raycast(_movementController.pinsa.position, vectorToGrab, out hit, distance, hitLayerMask);
    }
}

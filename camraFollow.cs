using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class CameraFollow : MonoBehaviour
{

public Transform camra;
public Transform target;
private float mouseX;



public float sensitivity;

public carController carController;
public float rotationResetSpeed = 2f;
public float DrotationResetSpeed = 2f;





 private void Update() {

    MouseInputs();
    rotation();
cursore();
targetRotationControl();
    
    
}


private void cursore(){

    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible =false;
}

private void MouseInputs(){

    mouseX =Input.GetAxis("Mouse X")*Mathf.Rad2Deg*sensitivity;
  
}





private void rotation(){

        target.rotation = Quaternion.Euler(target.eulerAngles.x, target.eulerAngles.y + (mouseX), target.eulerAngles.z);

camra.rotation =target.rotation;





}
private void targetRotationControl(){

  
    Vector3 currentRotation = target.transform.localEulerAngles;


    currentRotation.x = NormalizeAngle(currentRotation.x);
    currentRotation.y = NormalizeAngle(currentRotation.y);

    // Check if the rotation exceeds 1 degree on X or Y axis
    if (Mathf.Abs(currentRotation.x) > 1 || Mathf.Abs(currentRotation.y) > 1)
    {
       

    currentRotation.x = NormalizeAngle(currentRotation.x);
    currentRotation.z = NormalizeAngle(currentRotation.z);


    if (Mathf.Abs(currentRotation.x) > 1 || Mathf.Abs(currentRotation.z) > 1)
    {
       
        float newX = Mathf.Lerp(currentRotation.x, 0, Time.deltaTime * rotationResetSpeed);
        float newZ = Mathf.Lerp(currentRotation.z, 0, Time.deltaTime * rotationResetSpeed);

  
        target.transform.localEulerAngles = new Vector3(newX, currentRotation.y, newZ);
    }
}


float NormalizeAngle(float angle)
{
    if (angle > 180)
        return angle - 360;
    else if (angle < -180)
        return angle + 360;
    return angle;
}

if(Input.GetKey(KeyCode.W)){

            float newy = Mathf.Lerp(currentRotation.y, 2f, Time.deltaTime * DrotationResetSpeed);
   target.transform.localEulerAngles = new Vector3(currentRotation.x,newy , currentRotation.z);

}
if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)){

      float newy1 = Mathf.Lerp(currentRotation.y, 15f, Time.deltaTime * DrotationResetSpeed);
   target.transform.localEulerAngles = new Vector3(currentRotation.x,newy1 , currentRotation.z);
}
if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)){

      float newy2 = Mathf.Lerp(currentRotation.y, -15f, Time.deltaTime * DrotationResetSpeed);
   target.transform.localEulerAngles = new Vector3(currentRotation.x,newy2 , currentRotation.z);

}
if(Input.GetKey(KeyCode.S)){

      float newy2 = Mathf.Lerp(currentRotation.y, 179f, Time.deltaTime * DrotationResetSpeed);
   target.transform.localEulerAngles = new Vector3(currentRotation.x,newy2 , currentRotation.z);

}


    }
}





    


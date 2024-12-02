using NUnit.Framework.Constraints;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;


public class carController : MonoBehaviour

{   

// Car Wheel colliders
public WheelCollider Fl;
public WheelCollider Fr;
public WheelCollider Br;
public WheelCollider Bl;

// Car Wheel transform

public Transform Fltransform;
public Transform Frtansform;
public Transform Brtransform;
public Transform Bltransform;

// wheel Angle fix
public float FLANGLE;
public float FRANGLE;
public float BRANGLE;
public float BLANGLE;

// Car Inputs
private float horizontal;
private float vertical;


// Car Speed

public float PickUPSpeed;

public float maxSpeed;

public float breakpower;

public float minVelocity;
public float maxVelocity;




// Car sterring angle

public float sterringangles;

// Car physics

public Rigidbody rb;

private float forwardVelocity;

public Transform centerofmasobj;

private float Fstif;
private float Sstif;
private float fv;

public float stefnessdevider =15f;
public float stiffness =1f;


 private void Start() {
  StartCoroutine(fixwhellsuspention()); 
}


 private void Update() {

runCar();
Inputsvalue();
frictioncalculation();
SterringWheels();
centerofmass();
forcedetection();
breakSytem();
wheelRotations();

}




private void FixedUpdate() {
    bestHandeling();
}




// this is car Input system
private void Inputsvalue(){

horizontal=Input.GetAxis("Horizontal");
vertical =Input.GetAxis("Vertical");

}



// this method help to move the car right and left
private void SterringWheels(){

    Fr.steerAngle = sterringangles*horizontal;
    Fl.steerAngle = sterringangles*horizontal;
}





//  This is car wheel rotation with car WheelColider
private void wheelRotations(){

        Quaternion fl;
        Quaternion fr;
        Quaternion br;
        Quaternion bl;

        Vector3 FL;
        Vector3 FR;
        Vector3 BR;
        Vector3 BL;

       
        Fl.GetWorldPose(out FL, out fl);
        Fr.GetWorldPose(out FR, out fr);
        Br.GetWorldPose(out BR, out br);
        Bl.GetWorldPose(out BL, out bl);

        Fltransform.position =FL;
        Frtansform.position=FR;
        Brtransform.position=BR;
        Bltransform.position=BL;

   Fltransform.rotation =fl*Quaternion.Euler(0f,FLANGLE,0f);
        Frtansform.rotation=fr*Quaternion.Euler(0f,FRANGLE,0f);
        Brtransform.rotation=br*Quaternion.Euler(0f,BRANGLE,0f);
        Bltransform.rotation=bl*Quaternion.Euler(0f,BLANGLE,0f);
        

}






// This Method help to get car velocity
private void forcedetection(){


        Vector3 forwardDirection = transform.forward;
 forwardVelocity = Vector3.Dot(rb.linearVelocity, forwardDirection);

}





// This Method helps to give a centerofmass of car to make the car balance
private void centerofmass(){
rb.centerOfMass = centerofmasobj.localPosition; // Example: Lowering the center

}




// This Method calculate the car friction by velocity
private void frictioncalculation(){

if(forwardVelocity >0){
    fv = forwardVelocity/stefnessdevider;

    Fstif =fv+stiffness;
    Sstif =fv+stiffness;
}
}



// This Method apply the friction
private void bestHandeling(){

// Fl
   WheelFrictionCurve forwardFrictionL = Fl.forwardFriction;

    forwardFrictionL.stiffness = Fstif;
    Fl.forwardFriction = forwardFrictionL;

  WheelFrictionCurve sidewaywardFrictionL =Fl.sidewaysFriction;
    
    sidewaywardFrictionL.stiffness = Sstif;

    Fl.sidewaysFriction = sidewaywardFrictionL;

// Fr
    WheelFrictionCurve forwardFrictionR = Fr.forwardFriction;

    forwardFrictionR.stiffness = Fstif;
    Fr.forwardFriction = forwardFrictionR;

  WheelFrictionCurve sidewaywardFrictionR =Fr.sidewaysFriction;
    
    sidewaywardFrictionR.stiffness = Sstif;

    Fr.sidewaysFriction = sidewaywardFrictionR;

}




// This Method fix the wheel glitch
private IEnumerator fixwhellsuspention(){

      transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

  yield return new WaitForSeconds(0.1f);


  transform.position = new Vector3(transform.position.x, transform.position.y+2f, transform.position.z);
}


// This Method help to run the car
private void runCar() {
    float pickupspeed = vertical * PickUPSpeed + 0.051f;
    float lastspeed = vertical * maxSpeed + 0.051f;


    if (Mathf.Abs(vertical) < 0.1f) {

        Br.motorTorque = 0f;
        Bl.motorTorque = 0f;
        return;
    }

    if (forwardVelocity >= maxVelocity) {
        Br.motorTorque = 0f;
        Bl.motorTorque = 0f;
    } else if (forwardVelocity > minVelocity) {
        Br.motorTorque = lastspeed;
        Bl.motorTorque = lastspeed;
    } else {
        Br.motorTorque = pickupspeed;
        Bl.motorTorque = pickupspeed;
    }
}


// car breaking System
private void breakSytem() {
    if (Input.GetKey(KeyCode.Space)) {
        // Apply braking torque
        Fr.brakeTorque = breakpower;
        Fl.brakeTorque = breakpower;

        // Stop motor torque when braking
        Br.motorTorque = 0f;
        Bl.motorTorque = 0f;

        Debug.Log("Braking");
    } else {
        // Release brakes
        Fr.brakeTorque = 0f;
        Fl.brakeTorque = 0f;

        // Resume car operation
        runCar();
    }
}
}

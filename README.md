![image](https://github.com/user-attachments/assets/483f1a88-78dc-41b3-9d96-2385e0da9dd6)First is the car controller and the second one is the camera controller 
if you want to make a car then do those steps 

*****car contoller****

****Implimentation***



1/ in your car prefab seperate the body and the wheels 

2/ add a empty object in the car model and name it wheelColliders

3/in the empty object add 4 child empty object for the wheelCollider

4/and add  wheelcolider component in every 4 child object

5/adjust the coliders with the car wheels

6/make a empty object in car prefab with this name(car_center_of_mas) and reset it transform

7/add a empty object in car preefab and name it (terget)and adjust it in the center of car

8/drag the main camra or any camra in the terget object 

9/apply the carController.cs in the car prefab and fill the all component in the script

10/same apply the camraFollow.ca in the terget object and fill the all componet in the script




****Car Speed***

![Screenshot 2024-12-02 115018](https://github.com/user-attachments/assets/07a692c2-4483-433c-9b6f-5637f7bb465d)

Pickup speed ---- it gives you the first speed or the pickupspeed (Defult value=1000)

Max speed----it gives you the max speed of the car (Defult value=500)

breakpower --- it is a break strenth value (Defult value=1000)

min velocity -- it define picup speed -example - if you want your pickup speed mode then you need to increace the value ,then your car run in the pickup speed until the  valocity higher then the min velocity (Defult value=10)

max velocity -- it gives your car a speed limit (Defult value=30)




***Car steering handaling***

![Screenshot 2024-12-02 120338](https://github.com/user-attachments/assets/44c11475-2ffe-4eb3-ba97-d177d004c067)

steepnessdevider --- it gragualy increase your car sterring handaling by the valocity (Defult value=15)

stifness --- it gives you the defalt stifness (Defult value=1)




***Car wheel angals***

![Screenshot 2024-12-02 120338](https://github.com/user-attachments/assets/2f8dea84-6ead-4390-8545-80a67ad98b0c)

if your wheel is not set in perfect angale then you can adjust it

(Defult value=180) or (Defult value=0)

**camra follow**
![Screenshot 2024-12-02 121134](https://github.com/user-attachments/assets/c0d325c9-564b-4942-ac7b-a1c08bb899f4)

sensityvity --- you can adjust your mouse sencitycity (Defult value=0.1)









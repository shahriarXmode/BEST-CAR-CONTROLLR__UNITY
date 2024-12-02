First is the car controller and the second one is the camera controller 
if you want to make a car then do those steps 



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



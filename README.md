# Simulink in Unity3d
**tl;dr:** <br/>
Simple way to visualize a simulations from matlab/simulink in 3d by continously broadcasting the position and orientation to a Unity environment trough UDP <br/><br/>
**Requirements:**
- Unity3d
- Matlab/Simulink
- Embeded coder package (matlab)


## Background
This project is continuing of some of the work carried out in my masters thesis. I was tasked with setting up a simulation of an electric vessel that could be interacted with in a real-time 3d-environment. One of the things i were looking was to be able to use the simulink environment to set up everything i needed for the simulation, due to the ease of working with simulink as well as all the available packages for electromechanical systems. 
<br/><br/>
This led me to Unity, which were an easy alternative to set up a 3d model of the vessel and its environment to the degree i wanted. <br/>
The solution i came up with let Simulink calculate the position and orientation in real-time, while broadcasting the position to the Unity envorinment.<br/><br/>
I found this approach to be working well for my use-case, and think it can be a suitable alternative for visualising simulations. Also the Unity community is great with a lot of good tutorials which is super helpful.

<br/>


![unity2](https://user-images.githubusercontent.com/72814986/103153405-907e6f80-4790-11eb-856c-fb64b7925e2c.PNG)
*Simplified 3d-environement from my thesis running in Real-Time*



The coordinates of the vessel is broadcast as a string containing coordinates for x,y,z as well as Euler angles φ, ψ and θ defining the orientation 




![unity1](https://user-images.githubusercontent.com/72814986/103153202-3204c180-478f-11eb-89d4-5bcd1d0cf958.PNG)
*Implementation of the communication script to a cube object*
<br/>
## Setup:
In Unity: for the object you want to move with data trough UDP, simply add the 'UDP_TRANSFORM.cs' to the desired component, and drag the object that should move to the area named 'cube'. The Unity editor needs to be running the scene to recieve data (press the 'play' button) <br/>
![unity4](https://user-images.githubusercontent.com/72814986/103153762-18fe0f80-4793-11eb-988d-06310206d12f.PNG)
<br/>

In Simulink: The package "embeded coder" is required, as it contains the blocks "Send UDP" and "Byte Pack". The output should be a string with the position and orientation separated by "," example: "1.00,0,0,0,0,0"<br/>
The string then needs to be converted into ASCII and packaged as "uint-8": 
![Skjermbilde](https://user-images.githubusercontent.com/72814986/104330813-ac06ab80-54ee-11eb-9bd1-e88b133740a6.PNG)
*Simulink setup*

The file "UDP_simulink.slx" is set up and should work directly with the Unity environment if set up correctly. The version of matlab used is R2020b.



## Python
To test that the Unity environment is set up correctly, the python file 'Unity_communication.py' can be used. This broadcasts a string of (x,z,y,φ,ψ,θ):<br/><br/>
**Required python packages**:
- numpy


# Simulink in Unity3d
**tl;dr:** <br/>
Simple way to visualize a simulations from matlab/simulink in 3d by continously broadcasting the position and orientation to a Unity environment trough UDP <br/><br/>
**Requirements:**
- Unity3d
- Matlab/Simulink
- Embeded coder package (matlab)


## Background
This project is continuing of some of the work carried out in my masters thesis. I was tasked with setting up a simulation of an electric vessel that could be interacted with in a real-time 3d-environment. Since i was familiar with Simulink i really wanted to use this environment to set up the simulation due to all the available packages and general ease of working with and debugging block diagrammes. To visualise the simulation i looked into some simulink packages for 3d and found that the available software had old tutorials and documentation. After researching some more i saw some examples of using other software for visualising the data.

<br/><br/>
This led me to Unity, which offers a lot of helpful tutorials and have a very active community which were a great help. The solution i ended on were to use UDP to broadcast the position and orientation of the vessel from Simulink to Unity. This is a one way communication, meaning that Unity won't influence the simulation, only visualise what is happening. For my use-case this worked great, and i tought that i should make the resources used more available, since i used a lot of time to get find and get everything to work.



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
The string then needs to be converted into ASCII codes and packaged as "uint-8": 
![Skjermbilde](https://user-images.githubusercontent.com/72814986/104330813-ac06ab80-54ee-11eb-9bd1-e88b133740a6.PNG)
*Simulink setup*

The file "UDP_simulink.slx" is set up and should work directly with the Unity environment if set up correctly. The version of matlab used is R2020b.



## Python
To test that the Unity environment is set up correctly, the python file 'Unity_communication.py' can be used. This broadcasts a string of 6-numbers (position and orientation) separated by a comma: <br/><br/>
**Required python packages**:
- numpy


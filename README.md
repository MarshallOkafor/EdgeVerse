# EdgeVerse

**_EgdeVerse_** is a multi-user virtual reality application that has the multi-user networking and synchronization offloaded to an edge server. The main design strategy is to decouple the multi-user network operation (such as the connection processing and synchronization) from the scene rendering. With **_EgdeVerse_**, the VR client application is built to run locally and independently in the user device. The user participation in a shared or multi-user VR environment is handled by the connection server. The connection server runs at the edge of the network and leverages the PUN SDK to maintain user states and connection.

# Overview

**_EgdeVerse_** was developed using Unity3D platform and Photon Unity Networking (PUN) SDK. All the codes developed in this project were written in C#. We leveraged on some Unity Engine and PUN system modules to create the multi-user logic. The Photon Unity Networking system handles much of the network synchronization process using its in-built delta compression scheme.

The end user devices can be any head moundted device that uses OpenXR runtime such as HP Reverb, Samsung Odyssey, and Oculus Quest. The VR application can also be used in headless mode. That is, users can use **_EgdeVerse_** directly on their computers through their monitors and keyboard. The headless version was developed using Unity XR simulator plugin which allows customization of the headset and controllers through the keyboard and the mouse.

# Setup

## End User Aplication
To test **_EgdeVerse_**, ensure to have Unity3D installed on your computer. Clone this repository and build the aplication to the target end user device of your choice.  

### Important notice

**_EgdeVerse_** already has Unity XR simulator plugin already setup for use in the headless version. The scenes have the XR simulator GameObject added. You will need to disable this GameObject if you plan to use a physical head mounted device.

## Connection Server

The connection server used in this project is Windows 10 computer sitting at the edge of the network. I would recommend that you use the same. On the Windows computer, you will have to install and set up the PUN SDK for onpremise server. Use the Unity3D PUN2 plugin to modify the VR application to use the IP address of the Windows computer. Set the port details on the VR application to ```5055```. Ensure that the port is opened on the Windows computer and allows ```UDP``` connection.  

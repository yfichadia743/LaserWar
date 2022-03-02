# LaserWarVR

Clone the repository into a folder on your computer, or just download it as a zip file <br />
If downloading as a zip file, unzip the file into a folder <br />
Open the unity hub, and click add (upper right side), which will allow you to browse your computer and select the recently downloaded folder <br />
This should add the folder as a new unity project in your unity hub <br />
Make sure you have unity version 2020.3.11f1 downloaded, with android build support selected to install as well <br />
Setup and plug in the base stations, and make sure that the htc vive link box is turned on (small rounded black box with blue power button) <br />
After the base stations are plugged in, plug the htc vive tracker dongle into the computer and power on the vive tracker <br />
Attatch the vive tracker to a hand strap, making sure the green light is oriented away from the wrist, in line with the arm <br />
Open SteamVR, and make sure the headset is connected and detecting the base stations and vive tracker <br />
There should be two base stations and one vive tracker highlighted in blue <br />
It may ask you to go through the room setup, where it will guide you through a process to set the floor height and draw a guardian boundary <br />
You should now be able to open the unity project and select the laser war scene <br />
If the laser war scene is not selected by default (you do not see a black, space themed background), go to the project tab on the lower half of the screen, select scenes (under assets), and select the laser war scene <br />
To make sure the correct scripts are uploaded to both arduino boards, plug the arduino board on the glove into the computer and upload Peripheral_5Flex2.ino (Make sure the correct board and com port is selected) <br />
If the correct port isn't selected by default, go to the tools tab, then port, and check which port is selected. If none of the ports say Arduino Nano 33 BLE, you need to install the correct libraries for the bluetooth board <br />
Go to tools, board, then boards manager, which should allow you to search for "BLE" <br />
Install the Arduino MBed OS Nano Boards package <br />
The Ardunio Nano 33 BLE Sense should now be detected when you go to the ports secthe ion of the tools tab <br />
Select the correct port (should show that the arduino nano 33 BLE sense board is connected), and upload the Peripheral_5Flex2.ino file <br />
Unplug this board from the computer, then power it using the glove's battery <br />
Plug the second board into the computer, which will be used to communicate wirelessly to the glove, and reselect the port in the tools tab, it should be a different port but the steps will be the same, and remember this port number <br />
Upload the Central_5Flex2.ino file to the second board, and leave it plugged into the computer <br />
If you want, you can now check that the flex sensors and the glove are working by going to the tools tab and selecting either the serial monitor or the serial plotter
Make sure you close the serial monitor or plotter before running the unity project <br />
If you ever get a port busy message while trying to open the serial port, it may be because unity has not properly let go of the serial port, in this case unplugging and replugging the central arduino board should fix the issue <br />
Before running the unity project, look at the hierarchy tab on the left and click on vr_glove_left_model_slim. On the right side, the inspector tab should open <br />
Scroll down until you see the "Connect To Arduino" script, and click on the three dots on the right of the heading. At the bottom, click on edit script <br />
Once the script opens, you should look at line 9, where it says "public SerialPort sp = new SerialPort("COM17", 9600);" <br />
Where it says "COM17", change that to the COM port of the central arduino board, which you should have seen when uploading to the central arduino board <br />
You can now save the script and close it <br />
Now, you can run the unity project by selecting the play button at the top middle of the unity editor. If the project runs correctly, the button should turn blue <br />
You should be able to look around with the VR headset and move the vive tracker, which you can strap to your hand, to move the hand in VR around <br />
If the hand in VR does not move with the vive tracker, make sure it is on and connected in SteamVR <br />
If both of these are true, while the program is running, once again select the vr_glove_left_model_slim on the left side of the screen, under the hierarchy tab <br />
Scroll down on the right side, in the inspector tab, to the Steam VR_Tracked Object script, right above the Connect to Arduino script. <br />
This script should say index, and have a dropdown menu where you can select different devices. If you only have the headset, two base stations, and one vive tracker connected, the vive tracker should be device 3, but if not, it could be one of the other devices, so just select each device, from device 1 onwards until the hand moves with the vive tracker <br />
You can't save this change while the program is running, so to stop the program, press the play button on the top middle of the screen once more (it should turn from blue back to its original grey), then make the same change to the device number and do CTRL+S to save <br />



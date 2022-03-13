# WUControl
Windows Update manual control

**THIS TOOL DOES NOT JUST PAUSE WINDOWS UPDATES FOR SEVERAL DAYS.**

**IT STOPS WINDOWS UPDATES ALTOGETHER, PERMANENTLY UNTIL ENABLED AGAIN.** 

**YOUR DEVICE WILL NOT BE ABLE TO CHECK FOR UPDATES, EVEN WHEN CLICKING "CHECK FOR UPDATES" UNTIL ENABLED AGAIN.**

**Disclaimer: I am not responsible for any damages resulting from you not remember to enable updates back. It is YOUR decision to turn off and turn on automatic updates. Please do NOT forget to turn on updates when you're convenient.**

![image](https://user-images.githubusercontent.com/57480001/158051655-dae2f0db-c80a-492f-b1cc-c261b2986121.png)

This tool enables manual overriding the Windows Update component and avoid nasty unexpected reboots. There is only two buttons: Enable update and Disable update which does the exact function it claims. 

Do note that this tool does NOT stop the Windows Update services. Instead, it just points WU to localhost, where obviously no WU server (unless you do) would be running.

## Why?

Windows Update mostly sucks at deciding when to install updates. Even when it does, there's like a ton of small updates that needs to crank up my CPU to 100% for 10s of minutes. This is highly undesirable when I am travelling and has to work on battery. On desktop, especially demanding work programs (e.g Visual Studio with a huge solution), WU has a habit to chime in at the most intense phase (e.g building solution). 

I understand and want to have strictly fascist, authoritarian control over when WU does its things.

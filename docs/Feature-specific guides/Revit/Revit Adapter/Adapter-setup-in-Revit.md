BHoM is communicating with Revit via a dedicated plugin. Once BHoM is installed (or Revit_Toolkit compiled, if built from source), it should automatically load on startup of Revit 2018, 2019, 2020 and 2021. 

Activation of the plugin may be required upon starting Revit for the first time after BHoM installation. Simply click _Always Load_ not to see the popup again:

![Security Warning](https://user-images.githubusercontent.com/26874773/102640869-6e1a9f80-415b-11eb-9209-1111b3134667.png)

After that, if the adapter has been successfully loaded, it should be visible in the _BHoM_ ribbon tab in _Revit Adapter_ panel.

![Revit Listener](https://user-images.githubusercontent.com/26874773/102641715-d4ec8880-415c-11eb-927e-01d6aef79de9.png)

In order to activate the adapter, the user needs to click _Activate_ - Revit then starts to listen for BHoM instructions on default ports (14128 and 14129). As explained in the [introduction](Revit-Adapter-basics#introduction), only one Revit instance is allowed per each port couple - the latter can be changed by clicking _Update Ports_ button.
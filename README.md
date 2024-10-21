# PrintToBambu
Lets you upload and prints gcode files generatetd outside Bambu Studio on your Bambu printer.

This requires your printer is in "LAN only" mode, and you know the 'Access Code' displayed on the screen of the printer.

How it works:
1. FTP the gcode file to the printer
2. Subscribe to the periodic report send out by the printer's MQTT broker
3. Extract the device ID from the report
4. Using the device ID, publish a request to begin printing the uploaded gcode file to the printer's MQTT broker.

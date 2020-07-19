# GrillMaster
This project contains a netcore project that helps a barbecue chef  to optimize order in which barbecue items are grilled.

#Background
Since the space on the grill is limited and different grill items have different sizes, the program calculates the optimal schedule for grilling. The aim is to optimize the time for barbecuing the entire menu. The grill measures 20cm x 30cm. The cooking time is the same for all barbecue items.

A REST API provides different grill menus. The service returns a list of different pieces of meat with the required space. The solution calculates the order in which the food is placed on the grill and at the same time optimizes the duration of the entire meal. The console displays how many rounds are needed to grill the entire menu.

#Project
The solution consists in three projects: GrillMaster, GrillMasterClient and ConnectionManager.
  -The ConnectionManager is the project which manage the connection with the Rest Api.

  -The GrillMaster Client manages the interaction with the grill.

  -The GrillMaster is the main program.
#GrillMasterClient

The GrillMasterClient have three main tasks:
1: Parse the information received from the API into objects.
2: Plot the grill.
3: Put the objects into the grill, for do that the algorith, order the meal for volume and tries to put it into the grill from left to right and from the top to the bottom, first horizontally and if is not posible vertically, always with the objective to fill all the grill that is posible.


#Output

The output shows a graph of the grills with the position of the food, tracing the identification of the food and also shows the menus and rounds that have been necessary to be cooked.




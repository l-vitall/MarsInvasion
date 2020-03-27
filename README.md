!!NOTE: currently solution has an issue. As I just understood, 'x-coordinate followed by y-coordinate' actually means that first coordinate is a column number (x) and the second is a row number. Domn 'followerd' word, now it is treated vice versa. Will fix it today.

#Design:
Main entities:
 - MarsSurface
    - has borders
    - controls movements
    - has robots scents
    - the maximum value for any coordinate is 50
 - Robot
    - Has position
    - Has orientation
    - Accepts and executes commands
    - Can be lost
 - Commands
    - Turn Right
    - Turn Left
    - Step Forward
 - Commands set + commands string parser
    - less than 100 characters in length
 - MarsControlCenter
    - Sends new robots to Mars 
    - Puts new robots to specific position

#Estimation:
    For production it will require two days for development and unit testing


#Assumptions:
1. Lets consider that Mars surface borders are not known to program to see what will happen. Otherwise there is no sense to lose robots because we know borders initially
2. Moving down from zero pozition is also considered as robot loss
3. Dependency Injection logic from .net core should be used in the real code. Here for simplicity it is not used
4. Unit tests are not full, added the main ones only for demonstration purpose
    - Mor tests and test cases are required for production solution
5. Assuming that word “LOST” should be printed after last seen coordinates.
6. There is no currently need to use Command pattern. But since such provision is required - commands were added.
7. I used notation like Up, Down, Left, Right instead on N, S, W, E for better code readability. In case of using simple UI we will need to convert input value to inner format
8. I tried to keep solution structure simple since there are few logic and entities


#Tests:
1. Expected result for robot 
	3 2 N
	FRRFLLFFRRFLL
  is not correct. Robot moves succesfully to (4 2) without losing it. Robot cannot be lost on (3 3) because is it a valid cell since
  "The first line of input is the upper-right coordinates of the rectangular world", so (5 3) as upper-right coordinates actually means [6 4] matrix since coordinates are zero-based.

2. Initial position (03 W) is not correct, te space character is ommited. Should be (0 3 W)
   Test is not correct, robot leaves surface on the first F command. It seems that test were written for different coordinate system because the current one
    tells us "the lower-left coordinates are assumed to be 0,0.". Usually (0 0) is the upper-left cell.


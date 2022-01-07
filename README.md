# RobotsMartian

**List of assumptions**
1. We have only one surface
2. By default the surface has size of 50 in both directions.
3. Something sends string commands to the Robot control center (RCC) as one peace for all robots at once.
4. A letter is a robot command.
5. The whole script has a valid format and contains only valid instructions (as we won't lose any robots for nothing) otherwise it will never run.
6. RCC sends a robot to the surface and it can only send a command to change robot's position or orientation.
7. RCC does not store the robot position, orientation and status.
8. After each successful moves or changes orientation the robot notify RCC of its current position and orientation.
9. Neither robot, nor RCC do not know the grid limits only the surface does.
10. If the robot moved off the surface grid RCC would get an error as a response to the command (to simulate robot connection loss) and the robot would get a “lost” state
11. If the robot has “lost” state it will not receive or execute any commands.
12. RCC does not store robot instance after the last command in the instruction string (As it is not clear from the task if we need to save the robots for future use)
13. The robot can not act without landing on the surface and setting its initial coordinates.
14. The robot can sens a scent position only when it moves on the surface
15. The surface store the scents
16. We can expand the set of robot commands by realizing “IRobotInstruction” interface in a class and register the class with “AddSupportedInstruction” method of “RobotsController” class

To estimate the project, I assume that the entire solution should include technical documents and a simple user interface as well as a core module and unit tests.

**Martian robots project estimate:**

  * Clarify functional requirements – 1 hour
  * Create models, write unit tests and code for the core module - 9 hours
  * Write unit tests and code for the user interface - 2 hours
  * Run tests and fix bugs – 2 hours
  * Write technical documents for the solution – 2 hours

  Total estimated 16 hours

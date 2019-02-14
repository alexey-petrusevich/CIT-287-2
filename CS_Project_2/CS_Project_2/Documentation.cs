// Documentation class

/*
 * CIT-287
 * OOPL for Programmers
 * Programming Project 2 (C#)
 * 
 * Professor: Arland J. Richmond
 * Student: Aliaksei Petusevich
 * Date Submitted: March 3, 2018
 * Purpose: apply the knowledge of C# by solving particular problem
 * 
 * Description:
 * The project is designed to summarize students' knowledge about C# programming language.
 * According to project descriptions, students must create a program that simulates the behavior
 * of ATM machine. The project must contain three forms, each of which has a specific purpose:
 * 1) Login form and data validation
 * 2) Menu selection form
 * 3) Receipt form
 * In addition to that, the project requires saving user data in a file using local and master copy.
 * 
 * ---------------------------------------------------------------------------------------------------------------
 * After reviewing the requirements of the project, I have decided to create an adittional form - frmSelection -  
 * to promt the user additional information while prformin an ATM operation. Using 'Validator' class
 * created specifically for data validation purpose, the data on this form is validated. An ArgumentException with
 * the message is thrown by Validator and caught by frmSelection try-catch block.
 * 
 * frmMainMenu was designed to display menu options to the user represented by radio buttons. Upon pressing
 * each button, the user is taken to the frmSelection form with proper formating depening on user's selection.
 * Selecting "Exit" radio button and pressing "Select" button saves user account information to the local file.
 * 
 * frmLogin was designed to satisfy all requirements given by the project description:
 * - User has 3 attempts to login before the control buttons are disabled
 * - A rich text box display information about unsuccessfull entry or if control buttons are disabled
 * - The control is returned by typing ADMIN as 'login' and 123 as 'password'
 * - The only way to exit from application is by typing ADMIN as 'login' and 'BYE' as password
 * 
 * After numerous testing attempts, it had been concluded that current project satisfies all requirements
 * given by the project guidelines.
 */
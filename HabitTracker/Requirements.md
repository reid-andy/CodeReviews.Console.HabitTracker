## Requirements:
- Log occurrences of a habit 
 - Tracked by QTY not time
 - Users can input the date
 - Use Sqlite (build one with tables if not exists)
 - Full CRUD operations
	- Create habit
	- Read habits
 	- Update habits
 	- Delete habits
 - Handle ALL POSSIBLE ERRORS GRACEFULLY
 - No crashes
 - Use ADO.NET for database interactions
 - Dont repeat yourself
 - Project must contain a README.md file explaining how to use the application

 ## Tips:
 - UX: Give simple option to add today's date
 - Use a switch statement for user input menus
 - User input validation:
	- Ensure dates are valid and in correct format
	- Ensure quantities are positive integers
	- Confirm deletions and updates
 - Modular code structure: Separate methods for DB operations, user input, and display logic
 - Use parameterized queries to prevent SQL injection
 - Implement logging for error tracking and debugging
 - What happens if a menu option is selected that does not exist?
 - What happens if a user inputs a string when a number is expected?

## Challenges:
- Let users create custom habits (including unit of measurement for each habit)
- Seed the database with some example habits on first run
- Create a report feature whre users can view specific information
	- example: how many times a habit was performed and total quantity over a user-defined period

## Menu Options:
- Add a new habit
- Log an occurrence of a habit
- View all habits
- Update a habit
- Delete a habit
- View habit report
- Exit application
- Help / Instructions
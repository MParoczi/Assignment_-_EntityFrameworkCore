# Assignment - EntityFrameworkCore
This is the repository for the Entity Framework Core assignment of Codecool

The sole purpose of this repository is to practice the fundamentals of the .NET Core Entity Framework via a lightweight website

## How to run the application
To run the application you have to do the following:
1. Connect an empty database to the IDE
2. In the project root folder ```(~Blog/.)``` create a file named ```connection.env```
3. In the ```connection.env``` file type the following:
   ```dotenv
    HOST = Your host
    DATABASE = The name of your database
    USERNAME = Username for the database you attached to the application
    PASSWORD = Password for the user
   ```
4. Fill the required attributes in the ```connection.env``` file
5. Run the SQL file on your database that you can find at ```~/Blog/Data/Resources/database_config.sql```
6. After these steps you are able to run properly the application and the database will be filled with data
# EmployeeManager

I have used Database First Approach 

Database creation queries
-- Create the Users table
CREATE TABLE Users (
    Id INT PRIMARY KEY NOT NULL,
    Email VARCHAR(100),
    Password VARCHAR(100),
    Name VARCHAR(255),
    IsAdmin INT NOT NULL
);

-- Insert two rows of data
INSERT INTO Users (Id, Email, Password, Name, IsAdmin)
VALUES
    (1, 'user1@example.com', 'user1', 'User One', 1),
    (2, 'user2@example.com', 'user2', 'User Two', 1);




WebAPI Connects to the Database and provides Get,Get by {Id},Post, Put ,Delete and Login API Calls that are displayed in Swagger for testing.
WebInterface Layer is an MVC Application that Connects to the WebAPi and Performs the CRUD Operations.
Have a login page to check Creds that connects to the Login APi.


ScreenShots
![WebApi](https://github.com/kashakeel/EmployeeManager/assets/29459693/15bf2825-e6fb-464a-b989-20e0770809ac)
![Registration Page](https://github.com/kashakeel/EmployeeManager/assets/29459693/44ca94dc-29ac-4df7-9bb8-07dd6eb38df7)
![UsersPage](https://github.com/kashakeel/EmployeeManager/assets/29459693/9befecc3-9210-47e1-a275-6f201afb2895)

Thank You

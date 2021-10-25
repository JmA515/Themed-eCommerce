--CREATE DATABASE BOOKS_E_COMMERCE;

CREATE TABLE Users (
    Id int NOT NULL IDENTITY PRIMARY KEY,
    FirstName varchar(255) NOT NULL,
    LastName varchar(255) NOT NULL,
);

CREATE TABLE Roles (
    Id int NOT NULL IDENTITY PRIMARY KEY,
    RoleName varchar(255) NOT NULL,
);
CREATE TABLE UserRoles (
    UserId int,
    RoleId int,
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (RoleId) REFERENCES Roles(Id),
    CONSTRAINT PK_UserRoles PRIMARY KEY (UserId, RoleId)
);
CREATE TABLE Products (
    Id int NOT NULL IDENTITY PRIMARY KEY,
    ProductName varchar(255) NOT NULL,
    ProductDescription varchar(255),
    Price decimal NOT NULL,
    Genre varchar(255) NOT NULL
);
CREATE TABLE ShoppingCart (
    UserId int,
    ProductId int,
    Quantity int DEFAULT 1,
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (ProductId) REFERENCES Products(Id),
    CONSTRAINT PK_ShoppingCart PRIMARY KEY (UserId, ProductId)
);
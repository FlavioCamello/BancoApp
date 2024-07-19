CREATE DATABASE BankDB;
GO

USE BankDB;
GO

CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    CPF NVARCHAR(14) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME NOT NULL
);
GO

CREATE TABLE Accounts (
    AccountId INT PRIMARY KEY IDENTITY,
    CustomerId INT NOT NULL,
    AccountNumber NVARCHAR(20) NOT NULL,
    Balance DECIMAL(18, 2) NOT NULL,
    CreatedAt DATETIME NOT NULL,
    CONSTRAINT FK_Accounts_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);
GO

CREATE TABLE Transactions (
    TransactionId INT PRIMARY KEY IDENTITY,
    AccountId INT NOT NULL,
    TransactionType NVARCHAR(50) NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL,
    TransactionDate DATETIME NOT NULL,
    CONSTRAINT FK_Transactions_Accounts FOREIGN KEY (AccountId) REFERENCES Accounts(AccountId)
);
GO

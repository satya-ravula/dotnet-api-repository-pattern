CREATE TABLE Products (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    Price DECIMAL(10, 2) NOT NULL,
    PostedDate DATETIME NOT NULL,
    IsActive BIT NOT NULL
);

CREATE TABLE ProductQueues (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    ProductName NVARCHAR(255) NOT NULL,
    ProductData NVARCHAR(MAX) NOT NULL,
    RequestReason NVARCHAR(MAX),
    RequestDate DATETIME NOT NULL,
    Status NVARCHAR(50) NOT NULL
);


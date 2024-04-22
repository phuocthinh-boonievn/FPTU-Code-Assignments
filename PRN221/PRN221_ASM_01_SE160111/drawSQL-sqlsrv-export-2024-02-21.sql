CREATE DATABASE wpfManagement
go
use wpfManagement
go


CREATE TABLE "Category"(
    "categoryID" SMALLINT IDENTITY(1, 1) NOT NULL UNIQUE,
    "categoryName" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Category" ADD CONSTRAINT "category_categoryid_primary" PRIMARY KEY("categoryID");
CREATE TABLE "Store"(
    "storeID" SMALLINT IDENTITY(1, 1) NOT NULL UNIQUE,
    "storeLocation" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Store" ADD CONSTRAINT "store_storeid_primary" PRIMARY KEY("storeID");
CREATE TABLE "PC"(
    "productID" SMALLINT IDENTITY(1, 1) NOT NULL UNIQUE,
    "title" NVARCHAR(50) NOT NULL,
    "description" NVARCHAR(255) NOT NULL,
    "price" BIGINT NOT NULL,
    "imageLink" NVARCHAR(255) NULL,
    "review" BIGINT NULL,
    "status" BIT NOT NULL,
    "userID" SMALLINT NULL,
    "categoryID" SMALLINT NOT NULL,
    "storeID" SMALLINT NULL
);
ALTER TABLE
    "PC" ADD CONSTRAINT "electronics_productid_primary" PRIMARY KEY("productID");
CREATE INDEX "pc_userid_index" ON
    "PC"("userID");
CREATE INDEX "pc_categoryid_index" ON
    "PC"("categoryID");
CREATE INDEX "pc_storeid_index" ON
    "PC"("storeID");
CREATE TABLE "Accounts"(
    "userID" SMALLINT IDENTITY(1, 1) NOT NULL UNIQUE,
    "username" NVARCHAR(255) NOT NULL,
    "password" NVARCHAR(255) NOT NULL,
    "status" BIT NOT NULL,
    "role" BIGINT NOT NULL
);
ALTER TABLE
    "Accounts" ADD CONSTRAINT "accounts_userid_primary" PRIMARY KEY("userID");
ALTER TABLE
    "PC" ADD CONSTRAINT "pc_userid_foreign" FOREIGN KEY("userID") REFERENCES "Accounts"("userID");
ALTER TABLE
    "PC" ADD CONSTRAINT "pc_storeid_foreign" FOREIGN KEY("storeID") REFERENCES "Store"("storeID");
ALTER TABLE
    "PC" ADD CONSTRAINT "pc_categoryid_foreign" FOREIGN KEY("categoryID") REFERENCES "Category"("categoryID");
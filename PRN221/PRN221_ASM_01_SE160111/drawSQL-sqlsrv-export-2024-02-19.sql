create database ManagementWPF
go
use ManagementWPF
go

CREATE TABLE "Category"(
    "categoryID" SMALLINT NOT NULL,
    "categoryName" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Category" ADD CONSTRAINT "category_categoryid_primary" PRIMARY KEY("categoryID");
CREATE TABLE "Product"(
    "productID" SMALLINT NOT NULL,
    "title" NVARCHAR(255) NOT NULL,
    "description" BIGINT NOT NULL,
    "imageLink" NVARCHAR(255) NOT NULL,
    "review" BIGINT NOT NULL,
    "userID" SMALLINT NULL,
    "categoryID" SMALLINT NOT NULL
);
ALTER TABLE
    "Product" ADD CONSTRAINT "product_productid_primary" PRIMARY KEY("productID");
CREATE INDEX "product_userid_index" ON
    "Product"("userID");
CREATE INDEX "product_categoryid_index" ON
    "Product"("categoryID");
CREATE TABLE "Store"(
    "storeID" SMALLINT NOT NULL,
    "address" NVARCHAR(255) NOT NULL,
    "storeDescription" NVARCHAR(255) NOT NULL,
    "status" BIT NOT NULL,
    "inventory" BIGINT NOT NULL,
    "userID" SMALLINT NOT NULL
);
ALTER TABLE
    "Store" ADD CONSTRAINT "store_storeid_primary" PRIMARY KEY("storeID");
CREATE INDEX "store_userid_index" ON
    "Store"("userID");
CREATE TABLE "Accounts"(
    "userID" SMALLINT NOT NULL,
    "username" NVARCHAR(255) NOT NULL,
    "password" NVARCHAR(255) NOT NULL,
    "role" BIGINT NOT NULL
);
ALTER TABLE
    "Accounts" ADD CONSTRAINT "accounts_userid_primary" PRIMARY KEY("userID");
ALTER TABLE
    "Store" ADD CONSTRAINT "store_userid_foreign" FOREIGN KEY("userID") REFERENCES "Accounts"("userID");
ALTER TABLE
    "Product" ADD CONSTRAINT "product_userid_foreign" FOREIGN KEY("userID") REFERENCES "Accounts"("userID");
ALTER TABLE
    "Product" ADD CONSTRAINT "product_categoryid_foreign" FOREIGN KEY("categoryID") REFERENCES "Category"("categoryID");
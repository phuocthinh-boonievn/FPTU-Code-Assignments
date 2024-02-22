CREATE TABLE "Category"(
    "categoryID" SMALLINT NOT NULL UNIQUE,
    "categoryName" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Category" ADD CONSTRAINT "category_categoryid_primary" PRIMARY KEY("categoryID");
CREATE TABLE "Store"(
    "storeID" SMALLINT NOT NULL UNIQUE,
    "storeLocation" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Store" ADD CONSTRAINT "store_storeid_primary" PRIMARY KEY("storeID");
CREATE TABLE "Computer Electronics"(
    "productID" SMALLINT NOT NULL UNIQUE,
    "title" NVARCHAR(255) NOT NULL,
    "description" BIGINT NOT NULL,
    "price" BIGINT NOT NULL,
    "imageLink" NVARCHAR(255) NULL,
    "review" BIGINT NULL,
    "status" BIT NOT NULL,
    "userID" SMALLINT NOT NULL,
    "categoryID" SMALLINT NOT NULL,
    "storeID" SMALLINT NULL
);
ALTER TABLE
    "Electronics" ADD CONSTRAINT "electronics_productid_primary" PRIMARY KEY("productID");
CREATE INDEX "electronics_userid_index" ON
    "Electronics"("userID");
CREATE INDEX "electronics_categoryid_index" ON
    "Electronics"("categoryID");
CREATE INDEX "electronics_storeid_index" ON
    "Electronics"("storeID");
CREATE TABLE "Accounts"(
    "userID" SMALLINT NOT NULL UNIQUE,
    "username" NVARCHAR(255) NOT NULL,
    "password" NVARCHAR(255) NOT NULL,
    "status" BIT NOT NULL,
    "role" BIGINT NOT NULL
);
ALTER TABLE
    "Accounts" ADD CONSTRAINT "accounts_userid_primary" PRIMARY KEY("userID");
ALTER TABLE
    "Electronics" ADD CONSTRAINT "electronics_userid_foreign" FOREIGN KEY("userID") REFERENCES "Accounts"("userID");
ALTER TABLE
    "Electronics" ADD CONSTRAINT "electronics_storeid_foreign" FOREIGN KEY("storeID") REFERENCES "Store"("storeID");
ALTER TABLE
    "Electronics" ADD CONSTRAINT "electronics_categoryid_foreign" FOREIGN KEY("categoryID") REFERENCES "Category"("categoryID");
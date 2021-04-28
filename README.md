Notes

Connection String:
- You can keep the connection string as is, it will automatically generate the table schemas and seed data thanks to EntityFramework Code First.
- Or you can set the connection string to different server with an empty database, again it will automatically generate the table schemas and seed data.
- Or you can create a database and execute the Database/MMTShopDB-Scripts.sql file to create DB.

Clean Architecture - Domain Driven Design
- Project implemented with Clean Architecture (Onion Architecture).

MMT.Domain
- In MMT.Domain you can find domain objects such as Product and Category.
- In MMT.Domain.Abstractions, there are DTOs (Data Transfer Objects) and also interfaces to be implemented in MMT.Infrastructure project.

MMT.Domain.Test 
- Domain specific unit tests.
- Different test cases applied for a single unit test.

MMT.Infrastructure
- There is EntityFramework Core implementation of the Domain objects and repositories.
- There are service implementations, we could keep these services in Domain layer as well.

MMT.Infrastucture.Tests
- There are 2 test types here; Unit tests and Integration Tests.
- ProductRepository has a sql raw query execution, for this integration tests applied.
- Other repository and services has unit tests.
- Different test cases applied for a single unit test.
- Moq used

MMT.Web.API
- There are 2 controllers ProductContoller and CategoryController.
- Swagger used, so once the projects runs, you can execute any method from UI.
- Authenticaation and Authorization is not implemented, so anyone who has access to api can add product or category. 
- Considered this API will be in private network and the client app will have public IP. (Client app can have authentication and authorization).

MMT.ConsoleApp
- Console client added to test MMT.Web.API.
- You can set Multiple Startup Projects to run both MMT.Web.API and MMT.ConsoleApp

General:
- Exception handling implemented in MMT.Web.API.Middlewares.
- Adding new category checkes SKU range if it overlaps with other categories.
- We could add DomainEvents, but currently there is no business case for that.
- Currency field is not added since it will always be GBP
- Category SKUStart and SKUEnd columns define the range of the SKU. (SKUStared included, SKUEnd excluded)
- Specification usage > CategorySKURangeOverlapSpec
- "uspGetFeaturedProducts" Stored Procedure is not used in project but the creation script added to MMTShopDB-Scripts.sql
- CREATE PROC [dbo].[uspGetFeaturedProducts]
	AS
	SELECT p.* 
	FROM Product p
	JOIN Category c ON p.SKU >= c.SKUStart AND p.SKU < c.SKUEnd
	WHERE p.IsFeatured = 1
	AND c.CanBeFeatured = 1
- CREATE PROC uspGetProductsByCategory
	@IdCategory VARCHAR(36)
	AS
	SELECT p.* 
	FROM Product p
	JOIN Category c ON p.SKU >= c.SKUStart AND p.SKU < c.SKUEnd AND c.Id = @IdCategory

Feature: Login and Add product
		As a user
		I want to login the application
		So I can get Home page
		
		Scenario: Login
		Given I open "http://localhost:5000" url
		When I type "user" name, "user" password 
		And I open All Product
		And I Create new Product "Fortune cookie" ProductName, "Confections" Category, "Specialty Biscuits, Ltd." Supplier, "3,000" UnitPrice, "10 boxes x 15 pieces" QuantityPerUnit, "1" UnitsInStock, "3" UnitsOnOrder, "0" ReorderLevel
		Then check the product was created
Feature: Login and Add product
		As a user
		I want to login the application
		So I can get Home page
		
		Scenario: Login
		Given I open "http://localhost:5000" url
		When I type user
		And I open All Product
		And I Create new Product
		Then check the product was created


Feature: LoginFeature
	In order to view all employees
	As an admin of the website
	I need to be able to login and logout on the website
	

@mytag
Scenario: Successful login with valid credentials
	Given the user is at the login page
	When the user types in the'opensourcecms' and 'opensourcecms' then clicks the login button
	Then the user will be directed to the home page

Scenario: Successful logout
 Given the user is at the login page
 When the user types in the'opensourcecms' and 'opensourcecms' then clicks the login button
 When the user is at the home page and clicks the logout button
 Then the user will be directed to the login page


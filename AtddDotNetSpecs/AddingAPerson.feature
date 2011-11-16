Feature: Quick Add
	In order to keep track of the people I met at a conference
	As popular person
	I want to quickly add many people to my contact list
	

Scenario: Quick Add without Phone Number
	Given I am in the address book
	When I quick add John Doe
	Then John Doe should be added to the address book
	And John Doe should highlighted
	And Quick add name should be cleared


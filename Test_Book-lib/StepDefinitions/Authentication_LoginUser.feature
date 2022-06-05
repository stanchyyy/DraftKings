Feature: Authentication-Login

// Login

@tag1
Scenario: [Login user]
	Given [Create the user]
	When [I login]
	Then [I get authorization token]

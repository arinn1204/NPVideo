Feature: User wants to create tv episodes


	Scenario: A user wants to create a new tv episode
		Given a new tv episode
		When the user creates a new tv episode
		Then the user is told that it is created
		And the user receives a copy of the new tv episode
		
	@clean
	Scenario: A user wants to update an existing tv episode
		Given a tv episode already exists in the record
		When the user updates an existing tv episode
		Then the user is told that it was no content
		And the user receives nothing

Feature: UserWantsAccessToVideos

	Scenario Outline: A user wants to create a new video
		Given a user that wants to add a new <mediaType>
		When the user creates a new <mediaType>
		Then the user is told that it is created
		And the user receives a copy of the new <mediaType>

	Examples: 
	| mediaType  |
	| movie      |
	| tv episode |
		
	Scenario Outline: A user wants to update an existing video
		Given a <mediaType> already exists in the record
		When the user updates an existing <mediaType>
		Then the user is told that it was no content
		And the user receives nothing
		
	Examples: 
	| mediaType  |
	| movie      |
	| tv episode |


	Scenario Outline: A user wants to see all exiting videos
		Given a user that wants to see what <mediaType>s already exist
		When the user checks existing <mediaType>
		Then the user is shown all the existing <mediaType>

	Examples: 
	| mediaType  |
	| movie      |
	| tv episode |
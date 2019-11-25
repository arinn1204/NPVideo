Feature: UserWantsAccessToVideos

	Scenario: A user wants to create a new video
		Given a new video
		When the user creates a new video
		Then the user is told that it is created
		And the user receives a copy of the new video
		
	Scenario: A user wants to update an existing video
		Given a video already exists in the record
		When the user updates an existing video
		Then the user is told that it was successful
		And the user receives nothing

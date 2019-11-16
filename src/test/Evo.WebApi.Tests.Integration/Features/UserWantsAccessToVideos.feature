Feature: UserWantsAccessToVideos

	Scenario: A user wants to create a new video
		Given a user that wants to create a new video
		When the user interacts with the api
		Then the user is alerted that it is created
		And the user receives a copy of the new video
		
	Scenario: A user wants to update an existing video
		Given a user that wants to update a video
		When the user interacts with the api
		Then the user is told it was successful
		And the user receives a copy of the new video

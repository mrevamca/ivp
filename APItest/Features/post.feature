Feature: post

A short summary of the feature

@tag1
Scenario: validate success received for post request
	Given hit the post uri "https://reqres.in/api/users"
	Then success message is received for post request

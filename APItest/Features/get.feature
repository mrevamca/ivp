Feature: get

A short summary of the feature

@tag1
Scenario: validate success message for api get
	Given hit the uri "https://reqres.in/api/users?page=2"
	Then success message is received

Feature: registerpost

A short summary of the feature

@tag1
Scenario: validate register is successfull
	Given hit the register post uri "https://reqres.in/api/register"
	Then created success message received

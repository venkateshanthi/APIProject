Feature: GetAccesstoken

@mytag
Scenario: Get access token
	Given I have jwt access token
	When   I can see the status
	Then the result will be shown
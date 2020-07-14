Feature: PostProfile
	Test post operation using rest assured Library

@Smoke
Scenario: Verify post operation for profile 1
	Given I perform post operation for "/posts/{postid}/profile" with body
		| name | id |
		| Sams  | 1  |
	Then I should see the "name" name as "Sams"
Feature: Get file in the restsharp
@Tag
	Scenario: Verify author of the posts 1
	Given I perform GET operation for "posts/{postid}"
	And I perform operation for post "1"
	Then I should see the "author" name as "typicode"

	Scenario: Verify author of the posts 3
	Given I perform GET operation for "posts/{postid}"
	And I perform operation for post "3"
	Then I should see the "author" name as "shanthi"

	Scenario: Verify author of the posts 13
	Given I perform GET operation for "posts/{postid}"
	And I perform operation for post "13"
	Then I should see the "author" name as "Shanvi"

	Scenario: Verify author of the posts 30
	Given I perform GET operation for "posts/{postid}"
	And I perform operation for post "30"
	Then I should see the "author" name as "test5"
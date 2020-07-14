Feature: Get file in the restsharp for products

Background:
	Given I get Jwt authentication of user with following details
		| email           | password |
		| bruno@email.com | bruno    |

@Tag
Scenario: Verify author of the posts 1
	Given I perform GET operation for "products/{postid}"
	And I perform operation for post "1"
	Then I should see the "name" name as "Product002"

Scenario: Verify author of the posts 2
	Given I perform GET operation for "products/{postid}"
	And I perform operation for post "2"
	Then I should see the "name" name as "Product002"

Scenario: Verify author of the posts 13
	Given I perform GET operation for "products/{postid}"
	And I perform operation for post "3"
	Then I should see the "name" name as "Product003"
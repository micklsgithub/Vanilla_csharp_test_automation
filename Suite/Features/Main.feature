Feature: Main_
	To test the page content area

    Background: Go to Homepage
  Given I navigate to "Homepage" page as a "Anonymous" user
   When I wait for "1000" milliseconds

Scenario: Header_Links
   Then I should be on the "Homepage" page
   When I click the "Apply Now" button
   And I wait for "3000" milliseconds
   Then I should be on the "Grants" page

   
Feature: RestFeature

@mytag
Scenario: Get the response for the given url
	Given I have a resource /data/2.5/weather?zip=94040,us&appid=b6907d289e10d714a6e88b30761fae22
	When I do GET request on the end point
	Then the response should be in json format


Scenario Outline: Get API response for the given endpoint
	Given I have an url
	When I call the GET method on this endpoint using parameters <zip>,<country>,<appid>
	Then I need to get the user information in json format

Examples:Parameters info
| zip   | country | appid                            |
| 94040 | us      | b6907d289e10d714a6e88b30761fae22 |


Scenario Outline: Post content for the given end point
	Given I have a new resource /maps/api/place/add/json
	When I call the POST method on this endpoint using a key <postkey>
	Then the post response should be in json format

Examples:Key Info
| postkey    |
| qaclick123 |


Scenario Outline: Delete content for the given end point
	Given I have a delete resource /maps/api/place/delete/json
	When I call the POST method on this endpoint to delete using a key <deletekey>
	Then the delete response should be in json format

Examples:Key Info
| deletekey  |
| qaclick123 |
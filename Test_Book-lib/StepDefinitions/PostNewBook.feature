Feature: Add new book to library with title, author details, publisher and publish date.

@tag1
Scenario: [Post new book not present in the library]
	Given [Book not present in the library]
	When  [I login]
	Then  [I get authorization token]

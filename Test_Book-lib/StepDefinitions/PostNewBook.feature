Feature: Add new book to library

@TodoApp
Scenario: Post new book
	Given User is logged in
	| UserName     | EmailAddress   | Password     |
	| specflowTest | spec@spec.flow | specflowTest |
	And HTTP client is initialized
	And the given books are not present in the library
	| title                               | author.lastName | author.firstName | author.dateOfBirth       | publisher                   | releaseDate              |
	| Harry Potter - Philosopher's Stone  | Joanne          | Rowling          | 2002-06-07T14:15:22.630Z | Bloomsbury Publishing       | 2007-07-21T00:00:00.000Z |
	| Test Driven Development: By Example | Kent            | Beck             | 2003-06-07T14:15:22.630Z | Addison-Wesley Professional | 2002-10-01T00:00:00.000Z |
	| CSharp-Principles-Book-Nakov-v2018  | Svetlin         | Nakov            | 2004-06-07T14:15:22.630Z | unknown                     | 2018-05-01T00:00:00.000Z |

	When  [I login]
	Then  [I get authorization token]
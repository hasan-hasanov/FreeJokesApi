# FreeJokesApi
Free api that returns only the best jokes on the internet.

## Usage

Get all available jokes from the api.

```
GET /api/jokes/getall
```
Result in Json

```json
[
   {
      "id":"1",
      "category":"Stupid",
      "parts":[
         {
            "part":"Anton, do you think I’m a bad mother?",
            "order":1
         },
         {
            "part":"My name is Paul.",
            "order":2
         }
      ],
      "jokeFlags":[],
      "rating":3
   },
   {
      "id":"2",
      "category":"Stupid",
      "parts":[
         {
            "part":"The congress regarding hypochondria was canceled due to illness.",
            "order":1
         }
      ],
      "jokeFlags":[],
      "rating":2
   }
]
```

Get collection of jokes with parameters

```
GET /api/jokes/getJokes
```

Parameters

| Name          | Type          | Description  |
| :-------------|:-------------:| :-----------------------------------------------------------------------------|
| flags         | string        | By default the api does not return inapropriate jokes. If you want then you can request them here. |
| categories    | string        | Joke categories. You can add multiple categories like Categories=puns&Categories=programming       |
| ratingMin     | number        | Minimum rating that a joke must have. [0 10]                                                       |
| ratingMax     | number        | Maximum rating that a joke must have. [0 10]. This should be greater than ratingMin                |
| random        | bool          | Specify if the returned jokes should be random. Cannot be used with page parameter.                |
| page          | number        | Pagination functionality. Cannot be combined with random.                                          |
| pageSize      | number        | Jokes in a page [1 100]                                                                            |

## How To Contribute

**Did you find a bug?**

* Ensure the bug was not already reported by searching on GitHub under Issues.

* If you're unable to find an open issue addressing the problem, open a new one. Be sure to include a title and clear description, as much relevant information as possible.

**Did you write a patch that fixes a bug?**

* Open a new GitHub pull request with the patch.

* Ensure the PR description clearly describes the problem and solution. Include the relevant issue number if applicable.

**Did you fix whitespace, format code, or make a purely cosmetic patch?**

* Open a new GitHub pull request with the patch.

# FreeJokesApi
Free api that returns only the best jokes on the internet. If you don't agree, make a pull request with your favorite jokes.

## Usage

Get all available jokes from the api.

```
GET /api/jokes/getall
```
Result in Json

```json
[  
   {  
      "id":"5920ff05d9ab4203bb8a55b91fbf2250",
      "description":"Anton, do you think I’m a bad mother? My name is Paul.",
      "category":"Stupid"
   },
   {  
      "id":"81f67fdbf552427d95c3d40ad42bf142",
      "description":"The congress regarding hypochondria was canceled due to illness.",
      "category":"Stupid"
   },
   {  
      "id":"aaba4d9eea304971a22227a0f4fbdd39",
      "description":"A man enters a taxi with a hot dog. – Excuse me, this is not a restaurant! – I know. That’s why I brought my own food!",
      "category":"Stupid"
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
| categoryName  | string        | Name of the category to retrieve.                                             |
| count         | int           | Count of the jokes to retrieve. Can be combined with `categoryName` parameter.|

Retrieve list of categories

```
GET /api/categories
```

Result in Json

```json
[  
   {  
      "id":1,
      "name":"Stupid"
   },
   {  
      "id":2,
      "name":"Programmer"
   }
]
```
Get joke by Id

```
GET /api/jokes/getbyId?id=5920ff05d9ab4203bb8a55b91fbf2250
```
Result

```json
{  
   "id":"5920ff05d9ab4203bb8a55b91fbf2250",
   "description":"Anton, do you think I’m a bad mother? \n My name is Paul.",
   "category":"Stupid"
}
```

Get random joke from the api

```
GET /api/jokes/random
```

Parameters

| Name          | Type          | Description  |
| :-------------|:-------------:| :-----------------------------------------------------------------------------|
| categoryName  | string        | Name of the category to retrieve. This is optional parameter.                 |

Result

```json
{  
   "id":"81f67fdbf552427d95c3d40ad42bf142",
   "description":"The congress regarding hypochondria was canceled due to illness.",
   "category":"Stupid"
}
```

## How To Contribute

**You do not agree that these are the best jokes?**

* Add your favorite jokes [HERE](https://github.com/hasan-hasanov/FreeJokesApi/blob/master/Jokes/Jokes.json) in json format. For joke Id use a GUID without the hyphens. You can generate one from [online GUID generator](https://www.guidgenerator.com/online-guid-generator.aspx) and link the category id from [HERE](https://github.com/hasan-hasanov/FreeJokesApi/blob/master/Jokes/Categories.json). 
The joke json file has the following format:

```json
    {
      "id": "GUID without the hyphens",
      "description": "Your hilarious joke",
      "categoryId": "Id from Categories.json"
    },
```

* If your category does not exist yet, just add it [HERE](https://github.com/hasan-hasanov/FreeJokesApi/blob/master/Jokes/Categories.json).
The category json file has the following format:

```json
   {
      "id": "Next number from the file.",
      "description": "Category name"
    }
```

**Did you find a bug?**

* Ensure the bug was not already reported by searching on GitHub under Issues.

* If you're unable to find an open issue addressing the problem, open a new one. Be sure to include a title and clear description, as much relevant information as possible.

**Did you write a patch that fixes a bug?**

* Open a new GitHub pull request with the patch.

* Ensure the PR description clearly describes the problem and solution. Include the relevant issue number if applicable.

**Did you fix whitespace, format code, or make a purely cosmetic patch?**

* Open a new GitHub pull request with the patch.

- - - -

**Note:** _If there are new jokes and fixes I will make a release every Sunday._


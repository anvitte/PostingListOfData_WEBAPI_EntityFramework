# How you can call the api with list of data for posting the data in database

Step 1 - Before run follow some steps to enable migration approach for entity framework

Run following command in package console - tools -> Nuget package console -> Package console manager

I used entity framework to connect database 


1.   Enable-Migrations 

2.   Add-migration inital

3.   update-database


Step 2 - Run the project

Step 3 - Open Postman

Request Type - POST

URL - https://localhost:44347/api/QuestionModels/PostQuestionJson   - Check the locahost url in browser if different replace with localhost:44347 (when u run the project locally)

Header - Content-Type - application/json

BODY - Paste the json in body section and modify based on your requiement
```
[
	{
		"QuestionDescription":"which method you use for posting json data",
		"Answer":"POST"
	},
		{
		"QuestionDescription":"which method you use for getting json data",
		"Answer":"get"
	},
		{
		"QuestionDescription":"which method you use for updating json data",
		"Answer":"PUT"
	},
		{
		"QuestionDescription":"which method you use for delete json data",
		"Answer":"Delete"
	}
	

]
```

Click on send button to run the api.


#Step 4- To check the entry in database . Add new tab in postmane and run the GET command to check the data

Method - GET

URL - https://localhost:44347/api/QuestionModels


Happy Learning


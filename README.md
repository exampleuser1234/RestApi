# RestApi

***Import***
----
  Imports all cards from another project, and puts it into our backlog.
  
  `POST  /cards/import/:project_id` 
  
  **Response**
  
  ```
  200         Everything fine, cards've been imported.
  404         Project not found.
  500         Internal server error.
  ```
  
  
***Replace***
----
  Replaces all occurrances of one word on all cards in given column to another word.
  
  `POST  /cards/replace` 
  
  **Data params**
  ```json
  {
      "column":"Backlog",
      "pattern":"phrase to change",
      "change_to":"another word"
  }
  ```
  * *column* - column id or name
  * *pattern* - pattern to find
  * *change_to* - phrase to change found pattern to
  
  **Response**
  
  ```
  200         Everything fine.
  404         None cards found, matching given pattern.
  422         Something wrong with parameters.
  500         Internal server error.
  ```


  
***Move***
----
  Moves all cards with occurrances of one word in given column to another column.
  
  `POST  /cards/move` 
  
  **Data params**
  ```json
  {
      "column_from":"1234",
      "column_to":"1235",
      "pattern":"phrase to find"
  }
  ```
  * *column_from* - column to look for patterns id or name
  * *column_to* - id or name of column, which we move found cards to
  * *pattern* - pattern to find
  
  **Response**
  
  ```
  200         Everything fine.
  404         None cards found, matching given pattern.
  422         Something wrong with parameters.
  500         Internal server error.
  ```


  
***Delete***
----
  Delete all cards with occurrances of one word in given column.
  
  `DELETE  /cards` 
  
  **Data params**
  ```json
  {
      "column":"1234",
      "pattern":"phrase to find"
  }
  ```
  * *column* - column id or name
  * *pattern* - pattern to find
  
  **Response**
  
  ```
  200         Everything fine.
  404         None cards found, matching given pattern.
  422         Something wrong with parameters.
  500         Internal server error.
  ```




***Get logs***
----
  Get logs off all the operations.
  
  `GET /logs` 
  
  **Response**
  
  ```
  200         Everything fine.
  500         Internal server error.
  ```
  ```
  [
    {
        "id": {
            "timestamp": 1503528598,
            "machine": 3495253,
            "pid": 1,
            "increment": 14413831,
            "creationTime": "2017-08-23T22:49:58Z"
        },
        "operation": "Edit",
        "cardId": "4324592",
        "cardNote": "new note",
        "cardColumn": "1395592"
    }
  ]
  ```


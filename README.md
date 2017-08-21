# RestApi

***Import***
----
  Imports all cards from another project, and puts it into our backlog.
  
  `POST  /cards/import/:project_id` 
  
  **Response**
  
  ```
  200         Everything fine, cards've been imported.
  404         Project not found.
  ```
  
  
***Replace***
----
  Replaces all occurrances of one word on all cards in given column to another word.
  
  `POST  /cards/replace` 
  
  **Data params**
  ```json
  {
      "column_id":"1234",
      "pattern":"phrase to change",
      "change_to":"another word"
  }
  ```
  
  **Response**
  
  ```
  200         Everything fine, cards've been imported.
  422         Something wrong with parameters.
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
  
  **Response**
  
  ```
  200         Everything fine, cards've been imported.
  422         Something wrong with parameters.
  ```


  
***Delete***
----
  Delete all cards with occurrances of one word in given column.
  
  `DELETE  /cards` 
  
  **Data params**
  ```json
  {
      "column_id":"1234",
      "pattern":"phrase to find"
  }
  ```
  
  **Response**
  
  ```
  200         Everything fine, cards've been imported.
  422         Something wrong with parameters.
  ```




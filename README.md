# CorePlus

## Asumptions and Understanding

1. Currently, System don't have any database to fetch the data that why no repository and unit of work
2. As in current scope we don't have a lot of operations, So no need for CQRS
3. Currently, not using any cache or in-memory data management but can be added in the future for better performance 
4. No Custom Execption Hanlding is done but can be done in the system
5. Files path stored in the constant file bet can be moved json file and can be read from the configurations for better mangment. 
6. If user any date for the report filter then last 3 year report will be displayed
7. In future fluent validaion can be added to reduce the vunurablity and improve security. 
8. Pagging can be implented to improve response time for the user and avoid long wait

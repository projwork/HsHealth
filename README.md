# Why Dapper for read and EF core for write?

Dapper is prefered for complex read operation because it executes the raw sql.
We Prefer EF core for write operations because those operations are less latency sensitive and it gives developers productivity for it gives validations, strongly typed linq queries to reduce boilerplate for standard crud operations.

regarding test the test was done on a mock implementation of the repository and hence the filtering logic and the like of the script cannot be tested in unit test and for such scenario we need integration test. To fully validate the SQL logic and data filtering behavior, integration tests are required.

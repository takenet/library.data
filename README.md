Takenet Library.Data
============

Provides a simple abstraction for implementing the repository and unit of work patterns for data-enabled applications.

Components
----------

- **IUnitOfWork**: Interface for Unit of Work pattern implementation
- **IUnitOfWorkAsync**: Async version of Unit of Work interface
- **IEntityRepository**: Interface for Repository pattern implementation
- **IEntityRepository**: Async version of Repository interface (except AsQueryable method)


EntityFramework
---------------

The project **Data.EntityFramework** has an *Entity Framework* based implementation of the patterns. For the async support, the EF6 package is required.

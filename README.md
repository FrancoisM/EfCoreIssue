# EfCoreIssue
Reproduces an issue with EF Core conversions

This is a repro for [that stackoverflow issue.](https://stackoverflow.com/questions/61127859/i-have-an-invalidcastexception-despite-using-ef-core-hasconversion)

The tests pass with EF Core 3.1.3 but fail with EF Core 2.1.3 as well as 2.2.6.

There is a migration that need to be run first with: `dotnet ef database update`

# EfCoreIssue
Reproduces an issue with EF Core conversions

This is a repro for [that stackoverflow issue.](https://stackoverflow.com/questions/61127859/i-have-an-invalidcastexception-despite-using-ef-core-hasconversion)

There is a migration that need to be run first with: `dotnet ef database update`

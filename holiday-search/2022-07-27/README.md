# Notes

This Kata was done with outside-in TDD and avoiding the usage of mocking.

The down-sides to this approach is that the tests are not mocking out the data store, potentially resulting in brittle tests.

Also the whole dependency tree is needed in our test setup, which bloats the file.  The up-side is it is very fast to develop.

Used Visual Studio and dotnet6.
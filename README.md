Phazed.GuardClauses
===================

A simple project that implements guard clauses to validate the values of method arguments, and throw the appropriate
ArgumentException is they are not valid.

Each gaurd clause follows the pattern:

```C#
Guard.Against*XXXX*(*value*, "paramName");
```

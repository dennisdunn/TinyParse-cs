***Tiny Parse*** - A Parser Combinator Library
===

About
---
***Tiny Parse*** is a parser combinator library in C# to provide examples for the talk 
**Practical Parsing: Level Up With Parser Combinators**.

Generally, a parser is a function that takes a string and returns an object. In ***Tiny Parse***,
the Parser delegate describes a function that takes a Text object and returns a nullable dynamic.

A parser combinator is a function that takes one or more parsers and returns a new parser.

Text
---
A Text object encapsulates a string and a pointer into that string. If the ```length``` or
```position``` arguments result in an invalid text pointer then an ```BoundsError```
is thrown.

- Peek(length=1)
    - Return some characters from the string without advancing the pointer.
- Read(length=1)
    - Return some characters from the string and advance the pointer.
- Seek(position=0)
    - Set the string pointer to the specified position.

Base Parsers
---
These parsers throw a ```SyntaxError``` if they fail to match the current input.

- AnyOf
    - A parser which succeeds when the next character from the input is contained in the string argument.
    - ```AnyOf("0123456789")```
- Str
    - A parser which matches the string argument.
    - ```Str("hello, world")```

Parser Combinators
---

- Any 
    - Returns the first parser that succeeds.
    - ```Any(AnyOf("0123456789"), AnyOf("abcdef"))```
- All
    - Returns a parser which matches all of the arguments in order.
    - ```All(Str("hello"), Str(", "), Str("world"))```
- Many
    - Matches the argument 1 or more times.
    - ```Many(AnyOf("0123456789"))```
- Optional
    - Matches the argument 0 or 1 time. Always succeeds,
    potentially returning ```null``` as a result.
    - ```Optional(AnyOf(@" \t\r\n"))```
- Ignore
    - Tries to match the argument and ignores any errors. 
    Always returns ```null``` as a result.
    - ```Ignore(AnyOf(@" \t\r\n"))```
- Sequence
    - Matches each of the arguments and returns the results as a list.
    -  ```Sequence(Str('('), Many(AnyOf("0123456789")), Str(')'))```
- Apply
    - Tries to match the first argument and if successful, applies the second argument to the result.
    - ```Apply(Many(AnyOf("0123456789")), s => int.Parse(s))```


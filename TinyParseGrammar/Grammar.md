# Grammar

This is a simple grammar to parse arithmatic expressions.

**Terminals**
```
sum -> + | -
product -> * | /
open -> (
close -> )
sign -> + | -
digit -> 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 0
digits -> digit+
decimal -> . digits
unsigned -> digits | digits decimal
signed -> sign unsigned
number -> unsigned | signed
```

**Non-Terminals**
```
Expr -> Term Expr′
Expr′ -> sum Term Expr′ | ε
Term -> Factor Term′
Term′ -> product Factor Term′ | ε
Factor -> open Expr close | number
```

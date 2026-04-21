# ExpressionEvaluator

A math expression evaluator written in C# (.NET 10). It parses and evaluates arithmetic expressions entered as plain text, supporting standard operators and parentheses.

## How It Works

The evaluation pipeline has two stages:

1. **Lexer** (`ExpressionEvaluator.Core/Lexer.cs`) — Tokenizes the input string and converts it from infix notation to **Reverse Polish Notation (RPN)** using the [Shunting-yard algorithm](https://en.wikipedia.org/wiki/Shunting-yard_algorithm).
2. **Evaluator** (`ExpressionEvaluator.Core/Evaluator.cs`) — Walks the RPN token queue and computes the result using a stack.

## Supported Operators

| Operator | Symbol | Precedence |
|----------|--------|------------|
| Addition | `+` | 1 |
| Subtraction | `-` | 1 |
| Multiplication | `*` | 2 |
| Division | `/` | 2 |
| Modulo | `%` | 2 |

Parentheses `( )` are supported to override precedence.

## Input Format

Tokens **must be separated by spaces**. For example:

```
( 1 + 2 ) * 3
```


## Project Structure

```
ExpressionEvaluator/
├── ExpressionEvaluator.Core/        # Core library: Lexer, Evaluator, Token models
│   ├── Lexer.cs
│   ├── Evaluator.cs
│   └── Models/
│       ├── Token.cs
│       └── TokenType.cs
├── ExpressionEvaluator.App/         # Console application entry point
│   ├── Program.cs
│   └── Validators/
│       └── InputValidator.cs
└── ExpressionEvaluator.Tests/       # NUnit test suite
    └── ExpressionEvaluator.Test.cs
```



## Known Limitations & Areas for Improvement

- **Input format** — tokens must be space-separated
- **Operator coverage** — no support for exponentiation (`^`)
- **Test coverage** — currently a single test method covers all cases

## Additional Notes

- The project does not currently have a license.
- The project is still a work in progress.
- I tried to refrain from using AI for code generation

This README has been created by Copilot.


namespace ExpressionEvaluator.Core.Models;

public enum TokenType
{
    OperandToken,
    PlusToken,
    MinusToken,
    MultiplierToken,
    DivisionToken,
    ModuloToken,
    ExponentiationToken,
    OpeningParanthesisToken,
    ClosingParanthesisToken
}
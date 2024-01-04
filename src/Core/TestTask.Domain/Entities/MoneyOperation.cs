﻿using TestTask.Domain.Common;
using TestTask.Domain.Enums;

namespace TestTask.Domain.Entities;

public class MoneyOperation : Entity<MoneyOperationId>
{
	public MoneyAccountId? MoneyAccountFromId { get; init; }

	public MoneyAccountId? MoneyAccountToId { get; init; }

	public CommissionId? CommissionId { get; init; }

	public Commission? Commission { get; set; }

	public required decimal MoneyAmount { get; init; }

	public required DateTimeOffset OperationDate { get; init; }

	public required MoneyOperationTypes OperationType { get; init; }

	public required MoneyMoveTypes MoveType { get; init; }

	public MoneyOperation() : base() { }
}

public record MoneyOperationId(Guid Value) : IValueId<MoneyOperationId>
{
	public static MoneyOperationId Create() => new(Guid.NewGuid());
}
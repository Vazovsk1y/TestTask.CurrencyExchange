﻿using Microsoft.AspNetCore.Mvc;
using TestTask.Application.Services;
using TestTask.Domain.Entities;
using TestTask.WebApi.Common;
using TestTask.WebApi.ViewModels;

namespace TestTask.WebApi.Controllers;

[Route("api/money-accounts")]
public class MoneyAccountsController(
	IMoneyAccountService moneyAccountService) : AuthorizeController
{
	[HttpPost]
	public async Task<IActionResult> CreateMoneyAccount(MoneyAccountCreateModel createModel, CancellationToken cancellationToken)
	{
		var result = await moneyAccountService.CreateAsync(new CurrencyId(createModel.CurrencyId), cancellationToken);
		return result.IsSuccess ? Ok() : BadRequest(result.ErrorMessage);
	}

	[HttpGet("by-userId/{userId}")]
	public async Task<IActionResult> GetAssociatedWithUserMoneyAccounts(Guid userId, CancellationToken cancellationToken)
	{
		var result = await moneyAccountService.GetAllByUserIdAsync(new UserId(userId), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : BadRequest(result.ErrorMessage);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetMoneyAccountById(Guid id, CancellationToken cancellationToken)
	{
		var result = await moneyAccountService.GetByIdAsync(new MoneyAccountId(id), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : BadRequest(result.ErrorMessage);
	}
}
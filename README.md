# PettyCashLedger

A lightweight C# .NET console application to manage petty cash by recording income and expense transactions with structured summaries.

## Features
- Add Income & Expense transactions
- Interface-based reporting (IReportable)
- Abstract transaction model with inheritance
- Generic Ledger<T> for transaction storage
- Displays complete transaction history

## Core Components
-Transaction – Abstract base class
- IncomeTransaction, ExpenseTransaction – Derived entities
- Ledger<T> – Generic transaction manager
- IReportable – Reporting contract

## Tech Stack
C#
.NET Framework / .NET Core
OOP, Interfaces, Generics

## Run Project
```
git clone https://github.com/its-anuskapalit/PettyCashLedger.git
cd PettyCashLedger
dotnet run
```

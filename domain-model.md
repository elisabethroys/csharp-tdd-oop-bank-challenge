# Domain models

## Core requirements

1. As a customer, So I can safely store use my money, I want to create a current account.

| Classes           | Methods/Properties                                         | Scenario                                                                           | Outputs |
|-------------------|------------------------------------------------------------|------------------------------------------------------------------------------------|---------|
| Account.cs        | protected Account(decimal balance) {_balance = balance;}   | CurrentAccount.cs inherits from Account.cs and needs to provide an initial balance | bool    |
| CurrentAccount.cs | public CurrentAccount(decimal balance) : base(balance) { } | A customer can create a current acount with an inital balance                      | bool    |


2. As a customer, So I can save for a rainy day, I want to create a savings account.

| Classes           | Methods/Properties                                         | Scenario                                                                           | Outputs |
|-------------------|------------------------------------------------------------|------------------------------------------------------------------------------------|---------|
| Account.cs        | protected Account(decimal balance) {_balance = balance;}   | SavingsAccount.cs inherits from Account.cs and needs to provide an initial balance | bool    |
| SavingsAccount.cs | public SavingsAccount(decimal balance) : base(balance) { } | A customer can create a savings acount with an inital balance                      | bool    |


3. As a customer, So I can keep a record of my finances, I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

| Classes    | Methods/Properties               | Scenario                                     | Outputs |
|------------|----------------------------------|----------------------------------------------|---------|
| Account.cs | public void PrintBankStatement() | A customer can print their bank statement    | bool    |


4. As a customer, So I can use my account, I want to deposit and withdraw funds.

| Classes    | Methods/Properties                           | Scenario                                          | Outputs |
|------------|----------------------------------------------|---------------------------------------------------|---------|
| Account.cs | public virtual void Deposit(decimal amount)  | A customer can deposit money to their accounts    | bool    |
| Account.cs | public virtual void Withdraw(decimal amount) | A customer can withdraw money from their accounts | bool    |



## Extension requirements

1. As an engineer, So I don't need to keep track of state, I want account balances to be calculated based on transaction history instead of stored in memory.

| Classes    | Methods/Properties                                                                                                | Scenario                                         | Outputs |
|------------|-------------------------------------------------------------------------------------------------------------------|--------------------------------------------------|---------|
| Account.cs | public decimal GetCurrentBalance { get { return Transactions.Count == 0 ? 0 : Transactions.Last().NewBalance; } } | Calculated balances based on transaction history | bool    |


2. As a bank manager, So I can expand, I want accounts to be associated with specific branches.

| Classes    | Methods/Properties      | Scenario                                        | Outputs     |
|------------|-------------------------|-------------------------------------------------|-------------|
| Account.cs | private Branch _branch; | An account is associated with a specific branch | enum Branch |


3. As a customer, So I have an emergency fund, I want to be able to request an overdraft on my account.

| Classes           | Methods/Properties                          | Scenario                                                                          | Outputs |
|-------------------|---------------------------------------------|-----------------------------------------------------------------------------------|---------|
| CurrentAccount.cs | public void RequestOverdraft(decimal limit) | Request is added to a list of OverdraftRequests for that specific current account | bool    |


4. As a bank manager, So I can safeguard our funds, I want to approve or reject overdraft requests.

| Classes           | Methods/Properties                            | Scenario                                           | Outputs |
|-------------------|-----------------------------------------------|----------------------------------------------------|---------|
| CurrentAccount.cs | public void ApproveOrRejectOverdraftRequest() | A manager can approve or reject overdraft requests | bool    |

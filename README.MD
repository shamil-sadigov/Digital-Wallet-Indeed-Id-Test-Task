# Digital wallet web api

# Tech stack: 
- .NET 3.1
- EF Core 3.1
- SQLite
- FluentValidation
- MediatR

## How to use ?
### Example scenario:

User want to create a digit wallet with 2 accounts (USD and RUB). Then user want to increate the balance on USD account by 100$ and transfer 20$ of it to RUB Account. Afterwards, User want to view the current state of the accounts and view all operations done on it.


### Actions to do:
- Register new user in api/auth/register (when registered, by default new RUB account is created)
- Get user authentication token by providing user credentials in api/token/getUserAuthenticationToken
- Get persmission token in api/token/getPermissionToken. 
This token is necessary to have access to work with your account. To get permission token you should provide your authentication token in HTTP Request Authorization header.
Specify following permission names in request : ["account-create", "account-replenish", "account-state", "account-transfer"] OR you can request just ["all-permissions"] and get your persmission token.
- Create new USD account in /api/Account/Create. You should provide your permission token in HTTP Authorization header.
- Get your accounts' Id in /api/account/state. You will need accounts id to replenish and transfer. You should provide your permission token in HTTP Authorization header.
- Increates you balance on USD Account in api/account/replenish/. ou should provide your permission token in HTTP Authorization header.
- Transfer some funds from USD account to RUB account in api/account/transfer. You should provide your permission token in HTTP Authorization header.
- Get state of your accounts in api/account/state. You should provide your permission token in HTTP Authorization header.
- Get history of operations made on your accounts in api/account/operationHistory. You should provide your permission token in HTTP Authorization header.

### Setup
Follow these steps to get your development environment set up:

  1. Clone the repository
  2. At the E-Wallet directory, restore required packages by running:
     ```
     dotnet restore
     ```
  3. Next, build the solution by running:
     ```
     dotnet build
     ```
     
  4. Launch the applcation by running below command:
      ```
      dotnet run
      ```
	 
   5.   Go to https://localhost:5001:

## Web api documentation avaliable in swagger

![Docs](https://raw.githubusercontent.com/ShamilMS/Digital-Wallet-Indeed-Id-Test-Task/master/Docs/api-swagger.png)

### Expanded view

![Docs](https://raw.githubusercontent.com/ShamilMS/Digital-Wallet-Indeed-Id-Test-Task/master/Docs/api-swagger-documentation.png)
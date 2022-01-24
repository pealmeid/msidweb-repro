# msidweb-repro

Minimal Visual Studio project to illustrate the case described in [this issue](https://github.com/AzureAD/microsoft-identity-web/issues/1600).

To fully reproduce the case, you need to:

1. Create an Azure AD app registration that exposes an API with a scope named `right_scope`;
2. Update `appsettings.json` with your Azure AD app registration's `TenantId` ans `ClientId`;
3. Have a client app that authenticates the user agains the Azure AD and gets an access token for the `right_scope` scope.

Once you have the access token, make a call to the API endpoint passing the token in the `authentication` header.


There are 3 methods in the API, two with different required scopes defined in code and a third with the required scope defined in the `appsettings.json` configuration file:


Please refer to comments in `WatherForecastController.cs` to understand what happens in each case.

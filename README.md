# Upplysning.se .NET Client
[![.NET](https://github.com/mikaeldui/upplysning-dotnet-client/actions/workflows/dotnet.yml/badge.svg)](https://github.com/mikaeldui/upplysning-dotnet-client/actions/workflows/dotnet.yml)
[![CodeQL Analysis](https://github.com/mikaeldui/upplysning-dotnet-client/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/mikaeldui/upplysning-dotnet-client/actions/workflows/codeql-analysis.yml)

With this library you can look up the addresses, birthdates and more of all Swedish residents. You can also do reverse lookups.Example usage: verify customer information at checkout.

You can install it using the following **.NET CLI** command:

    dotnet add package MikaelDui.Upplysning.Client --version *

## Example

Lookup the address of a person.

    using UpplysningClient client = new();
    var result = await client.GetPeopleAsync("Anna");
    foreach(var person in result)
        Console.WriteLines($"{person.Name} lives on {person.Address} in {person.Address}.");

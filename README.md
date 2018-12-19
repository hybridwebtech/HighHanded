# HighHanded
  
This project was generated with [.NET Core](https://github.com/microsoft/dotnet) version 2.1.

## Development system

Install the [.NET Core 2.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/2.1).
Select the install appropriate to your hardware and O/S.

This application comes with a solution file (HighHanded.sln) and two projects, HighHandedApp and HighHandedTests.
Run `dotnet restore` to install/update required packages for this application.
Run `dotnet build` from the solution folder (where HighHanded.sln is located) to build the entire solution
To run the unit tests, change directory to HighHandedTests and run `dotnet test`.
To run the HighHanded application, change directory to HighHandedApp and run
`dotnet run`. After displaying the application title (High Hand!),
you must enter the number of games to be played. After that, enter pairs of poker hands to be evaluated.
Each 'hand' consists of exactly five characters taken from '*23456789TJQKA'. Press enter after typing in each pair
of hands. HighHanded will evaluate each pair and display the result.

For example, if you enter:

AAKKK 23456

HighHanded will respond with

FULLHOUSE STRAIGHT a

which indicates that the first hand is a Full House (a pair of aces and three kings), and the second hand contains a
Straight (five cards of consecutively increasing value, 2, 3, 4, 5, 6). Since a Full House beats a Straight,
HighHanded indicates that the first hand, indicated by 'a', is the winner.


## Build

Run `dotnet build` from the solution folder to build the entire solution. The build artifacts will be stored in the
`bin` directories of each prohect.

## Running unit tests

Run `dotnet test` from the HighHandedTest folder to execute the unit tests.

## Further help

To get more help on the dotnet CLI use `dotnet -h` or go check out the [.NET Core README](https://github.com/Microsoft/dotnet/blob/master/README.md).

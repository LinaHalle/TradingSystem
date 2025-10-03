# TradingSystem

A simple C# console application for trading items between users.
In the main branch I only save users, items and trades in the local memory in the console
In the persistentdata branch I created a version that saves the data to files

## Features

- User registration and login
- Add items to your account
- Browse other users' items
- Request trades
- Accept or deny trade requests
- View completed trades

## Getting Started

Clone this repository and run it with .NET:

- bash
- git clone <repo-url>
- cd TradingSystem-main
- dotnet run

## Project Structure

- Program.cs - main entry point with menus and logic
- User.cs - represents a user with items and trades
- Item.cs - represents an item with name, description and owner
- Trade.cs - represents a trade request between two users

## Example run

Welcome to TradeHub
------------- Log-in page -------------

- Do you already have an account, choose: 1. to login
- Do you want to create an account, choose: 2. to register

---

TradeHub main menu, choose any of the options

1. Upload an item
2. Browse existing items of other users
3. Request a trade for someone's item
4. Accept/Deny a trade request
5. Browse completed trades
6. Logout

## Future improvements

- Create more methods/functions to avoid re-writing code more than once
- Improve error handling and input validation
- Add unique trade Ids for better tracking
- Support updating or removing items

## Purpose of project

- Made as a first assignment project to practice C# and object-oriented programming

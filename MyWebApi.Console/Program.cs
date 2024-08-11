// See https://aka.ms/new-console-template for more information

//using System;

//Console.Write("Hello world");

using Microsoft.AspNetCore.SignalR.Client;

var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5026/maphub")
    .WithAutomaticReconnect()
    .Build();
    
await connection.StartAsync();

connection.SendAsync("Test");
connection.SendAsync("SendMessage", "Hello from console!");
using ConsoleClient;

Client client = new Client();
await client.Connect();
Console.Read();
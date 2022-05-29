// See https://aka.ms/new-console-template for more information

using SnowStormSample.DbScripts.Infrastructure;

Console.WriteLine("Hello, World! Getting ready to run some DB scripts...");

try
{
    Console.WriteLine("--------------------------------");

    ScriptExecutor scriptExecutor = new(args);
    scriptExecutor.PerformUpgrade();

    Console.WriteLine("DONE.  DB upgrade completed.");
    Console.WriteLine("--------------------------------");
}
catch (Exception ex)
{
    Console.WriteLine("DONE.  DB upgrade FAILED!");
    Console.WriteLine("--------------------------------");
    Console.WriteLine(ex.Message);
    if (!string.IsNullOrWhiteSpace(ex.StackTrace))
        Console.WriteLine(ex.StackTrace);
    Console.WriteLine("--------------------------------");
}
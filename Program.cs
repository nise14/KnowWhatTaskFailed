// See https://aka.ms/new-console-template for more information
Console.WriteLine("Start");

var tasks = new List<Task>{
    Task1(),
    Task2(),
    Task3()
};

try
{
    await Task.WhenAll(tasks);
}
catch (Exception ex)
{
    var taskFailed = tasks.Where(t => t.IsFaulted).ToList();

    foreach (var task in taskFailed)
    {
        var exc = task.Exception?.InnerException;
        var nameMethod = exc.Data["Name Method"];
        Console.WriteLine($"Ha fallado el metodo {nameMethod}");
    }
}

Console.WriteLine("End");

async Task Task1()
{
    await Task.Delay(1000);
}

async Task Task2()
{
    await Task.Delay(1000);
}

async Task Task3()
{
    try
    {
        await Task.Delay(1000);
        throw new Exception();
    }
    catch (Exception ex)
    {
        ex.Data["Name Method"] = nameof(Task3);
        throw;
    }
}
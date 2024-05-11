// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");

//while (true)
//{
    Stopwatch stopwatch = new Stopwatch();

    Console.WriteLine("Parallel Foreach Loop Started");

    stopwatch.Start();

    List<int> integerList = Enumerable.Range(1, 10).ToList();

    Parallel.ForEach(integerList, i =>
    {
         DoSomeIndependentTimeConsumingTask().GetAwaiter().GetResult();
        //Console.WriteLine("{0} - {1}", i, total);
    });

    //foreach (var i in integerList)
    //{
    //    long total = DoSomeIndependentTimeConsumingTask();
    //    Console.WriteLine("{0} - {1}", i, total);
    //}

    Console.WriteLine("Parallel Foreach Loop Ended");

    stopwatch.Stop();

    Console.WriteLine($"Time Taken by Parallel Foreach Loop in Miliseconds {stopwatch.ElapsedMilliseconds}");
    Console.ReadLine();
//}


async Task DoSomeIndependentTimeConsumingTask()
{
    //Thread.Sleep(2000);

    // Create an instance of HttpClient
    using (HttpClient client = new HttpClient())
    {
        try
        {
            // URL you want to fetch data from
            string url = "https://reqres.in/api/users";

            // Send a GET request to the specified URL
            HttpResponseMessage response = await client.GetAsync(url);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Output the content
                Console.WriteLine(content);
            }
            else
            {
                // Output the status code if request was not successful
                Console.WriteLine("Request was not successful: " + response.StatusCode);
            }
        }
        catch (HttpRequestException e)
        {
            // Handle any exceptions that might have occurred
            Console.WriteLine("Error: " + e.Message);
        }
    }
}


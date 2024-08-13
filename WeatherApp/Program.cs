using Newtonsoft.Json.Linq;

namespace WeatherApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var client = new HttpClient();

			var key = "6deab23cecd72a05bd988eb02a5be361";

			while (true)
			{
                Console.WriteLine();
                Console.WriteLine("Please enter the city name: ");
				var city_name = Console.ReadLine();
                Console.WriteLine();

				var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid={key}";

				try
				{
					var response = client.GetAsync(weatherURL).Result;
					var responseContent = response.Content.ReadAsStringAsync().Result;

					if (responseContent != null)
					{
						var formattedResponse = JObject.Parse(responseContent).GetValue("main")?.ToString();
						var temp = JObject.Parse(formattedResponse).GetValue("temp");
						Console.WriteLine($"The current Temperature is {temp} degrees Fahrenheit");
					}
					
				}
				catch (Exception e)
				{
                    Console.WriteLine(e.Message);
                }

				AddSpaces(2);
				Console.WriteLine("Would you like to exit?");
				var userInput = Console.ReadLine();
				AddSpaces(2);

				if (userInput.ToLower().Trim() == "yes")
				{
					break;
				}
			}
        }

		private static void AddSpaces(int count)
		{
			for (int i = 0; i < count; i++)
			{
                Console.WriteLine();
            }
		}
	}
}

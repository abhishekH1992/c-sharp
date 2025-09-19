using System.Net;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user for input
        Console.WriteLine("Please enter conversion type -\n" +
                            "1 for celsius to fahrenheit,\n" +
                            "2 for fahrenheit to celsius, \n" +
                            "3 for kilometers to miles, \n" +
                            "4 for miles to kilometers:");

        // Read the user's input
        int conversionType = int.Parse(Console.ReadLine()!);

        if (conversionType != 1 && conversionType != 2 && conversionType != 3 && conversionType != 4) {
            Console.WriteLine("Invalid conversion type");
            return;
        }

        switch (conversionType) {
            case 1:
                Console.WriteLine("Please enter the temperature in celsius:");
                double celsius = double.Parse(Console.ReadLine()!);
                double convertedFahrenheit = ConvertCelsiusToFahrenheit(celsius);
                Console.WriteLine($"{celsius}°C is {convertedFahrenheit}°F");
                break;
            case 2:
                Console.WriteLine("Please enter the temperature in fahrenheit:");
                double fahrenheit = double.Parse(Console.ReadLine()!);
                double convertedCelsius = ConvertFahrenheitToCelsius(fahrenheit);
                Console.WriteLine($"{fahrenheit}°F is {convertedCelsius}°C");
                break;
            case 3:
                Console.WriteLine("Please enter the killometers:");
                double kilometers = double.Parse(Console.ReadLine()!);
                double convertedMiles = ConvertKilometersToMiles(kilometers);
                Console.WriteLine($"{kilometers}km is {convertedMiles}mi");
                break;
            case 4:
                Console.WriteLine("Please enter the miles:");
                double miles = double.Parse(Console.ReadLine()!);
                double convertedKilometers = ConvertMilesToKilometers(miles);
                Console.WriteLine($"{miles}mi is {convertedKilometers}km");
                break;
        }
    }

    static double ConvertCelsiusToFahrenheit(double celsius) {
        return (celsius * 9 / 5) + 32;
    }

    static double ConvertFahrenheitToCelsius(double fahrenheit) {
        return (fahrenheit - 32) * 5 / 9;
    }

    static double ConvertKilometersToMiles(double kilometers) {
        return kilometers * 0.621371;
    }

    static double ConvertMilesToKilometers(double miles) {
        return miles * 1.60934;
    }
}
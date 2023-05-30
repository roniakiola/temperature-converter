bool running = true;

while (running)
{
  Console.WriteLine("Provide temperature and scale. (Examples: 25 C or 10 F)");
  string? input = Console.ReadLine();
  string[] inputParts = input.Split(' ');

  if (input.ToLower() == "exit")
  {
    running = false;
    Console.WriteLine("Exiting program");
    break;
  }

  string scale = inputParts[1].ToUpper();

  if (!double.TryParse(inputParts[0], out double temperature) || (scale != "F" && scale != "C") || (inputParts.Length != 2))
  {
    Console.WriteLine("Please provide valid temperature value and scale. (Examples: 25 C or 10 F)");
    continue;
  }

  double convertedTemp = TempConvert(temperature, scale);
  Console.WriteLine($"{input} equals to {convertedTemp} {(scale == "C" ? "F" : "C")}");
}

static double TempConvert(double temperature, string scale)
{
  switch (scale)
  {
    case "C":
      return Math.Round((temperature * 9 / 5) + 32, 2);

    case "F":
      return Math.Round((temperature - 32) * 5 / 9, 2);

    default:
      Console.WriteLine("Invalid inputs");
      return temperature;
  }
}
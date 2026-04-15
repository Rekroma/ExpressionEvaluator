using ExVal.Services;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Please enter your expression and confirm with [ENTER]:");

        string validatedInput = InputService.GetValidatedInput();
    }
}

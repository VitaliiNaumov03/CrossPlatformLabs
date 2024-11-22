using System;
using System.IO;
using McMaster.Extensions.CommandLineUtils;
using ClassLibrary;

namespace Lab4
{
    [Command(Name = "lab4", Description = "Run labs using ClassLibrary")]
    [HelpOption("--help")]
    class Program
    {
        [Option("-I|--input <FILE>", "Path to the input file", CommandOptionType.SingleValue)]
        public string? InputFile { get; }

        [Option("-o|--output <FILE>", "Path to the output file", CommandOptionType.SingleValue)]
        public string? OutputFile { get; }

        [Option("--version", "Show version information", CommandOptionType.NoValue)]
        public bool ShowVersion { get; }

        [Option("-p|--path <PATH>", "Set default path for files", CommandOptionType.SingleValue)]
        public string? DefaultPath { get; }

        [Argument(0, Description = "Command to execute (run, set-path, version)")]
        public string? Command { get; }

        [Argument(1, Description = "Lab to run (lab1, lab2, lab3)")]
        public string? Lab { get; }

        static void Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        private void OnExecute()
        {
            if (ShowVersion)
            {
                Console.WriteLine($"Author: Vitalii Naumov\nVersion: 1.0.0");
                return;
            }

            if (string.IsNullOrEmpty(Command))
            {
                Console.WriteLine("Please specify a command (run, set-path, version).");
                return;
            }

            switch (Command.ToLower())
            {
                case "run":
                    RunLab();
                    break;
                case "set-path":
                    SetPath();
                    break;
                default:
                    Console.WriteLine($"Unknown command: {Command}. Use --help for usage.");
                    break;
            }
        }

        private void RunLab()
        {
            if (string.IsNullOrEmpty(Lab))
            {
                Console.WriteLine("Please specify a lab to run (lab1, lab2, lab3).");
                return;
            }

            string labNumber = Lab.Replace("lab", "").Trim();
            if (!int.TryParse(labNumber, out _))
            {
                Console.WriteLine($"Invalid lab specified: {Lab}");
                return;
            }

            string inputPath = InputFile ?? GetDefaultPath($"input{labNumber}.txt");
            string outputPath = OutputFile ?? GetDefaultPath($"output{labNumber}.txt");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            var runner = new LabRunner();

            try
            {
                switch (Lab.ToLower())
                {
                    case "lab1":
                        runner.RunLab1(inputPath, outputPath);
                        break;
                    case "lab2":
                        runner.RunLab2(inputPath, outputPath);
                        break;
                    case "lab3":
                        runner.RunLab3(inputPath, outputPath);
                        break;
                    default:
                        Console.WriteLine($"Unknown lab: {Lab}");
                        return;
                }
                Console.WriteLine($"Lab {Lab} completed. Output saved to {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error running {Lab}: {ex.Message}");
            }
        }

        private void SetPath()
        {
            if (string.IsNullOrEmpty(DefaultPath))
            {
                Console.WriteLine("Please specify a path to set.");
                return;
            }

            Environment.SetEnvironmentVariable("LAB_PATH", DefaultPath, EnvironmentVariableTarget.User);
            Environment.SetEnvironmentVariable("LAB_PATH", DefaultPath, EnvironmentVariableTarget.Process);
            Console.WriteLine($"Default path set to: {DefaultPath}");
        }

        private string GetDefaultPath(string fileName)
        {
            string? envPath = Environment.GetEnvironmentVariable("LAB_PATH");
            if (!string.IsNullOrEmpty(envPath))
            {
                return Path.Combine(envPath, fileName);
            }
            else
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), fileName);
            }
        }
    }
}
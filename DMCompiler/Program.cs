using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenDreamShared.Compiler;

namespace DMCompiler {
    class Program {
        static void Main(string[] args) {
            if (!TryParseArguments(args, out DMCompilerSettings settings)) return;

            if (!DMCompiler.Compile(settings)) {
                //Compile errors, exit with an error code
                Environment.Exit(1);
            }

            if (!DMCompiler.Settings.QuitOnCompletion)
            {
                var msg = "Enter 'exit' to quit or '--help' for more options";
                string input;
                do
                {
                    Console.WriteLine(msg);
                    input = Console.ReadLine();
                    HandleCommand(input);
                } while (input != "exit");
                Environment.Exit(0);
            }
        }

        private static void HandleCommand(string input)
        {
            switch (input)
            {
                case "--help":
                {
                    Console.WriteLine("Valid commands:");
                    Console.WriteLine("\t--help - See this info");
                    Console.WriteLine("\t--exit - Exit the program. 'exit' also works");
                    break;
                }
                case "--exit":
                case "exit":
                {
                    Environment.Exit(0);
                    break;
                }
                default:
                    Console.WriteLine($"Unknown command '{input}'");
                    break;
            }
        }

        private static bool TryParseArguments(string[] args, out DMCompilerSettings settings) {
            settings = new();
            settings.Files = new List<string>();
            
            bool skipBad = args.Contains("--skip-bad-args");

            foreach (string arg in args) {
                switch (arg) {
                    case "--suppress-unimplemented": settings.SuppressUnimplementedWarnings = true; break;
                    case "--dump-preprocessor": settings.DumpPreprocessor = true; break;
                    case "--no-standard": settings.NoStandard = true; break;
                    case "--verbose": settings.Verbose = true; break;
                    case "--incremental-dmm":
                    {
                        settings.IncrementalDMM = true;
                        settings.QuitOnCompletion = false;
                        break;
                    }
                    case "--skip-bad-args": break;
                    default: {
                        string extension = Path.GetExtension(arg);

                        if (!String.IsNullOrEmpty(extension) && (extension == ".dme" || extension == ".dm")) {
                            settings.Files.Add(arg);
                            Console.WriteLine($"Compiling {Path.GetFileName(arg)}");
                        } else {
                            if(skipBad) {
                                DMCompiler.Warning(new CompilerWarning(Location.Unknown, $"Invalid compiler arg '{arg}', skipping"));
                            } else {
                                Console.WriteLine($"Invalid arg '{arg}'");
                                return false;
                            }
                        }

                        break;
                    }
                }
            }

            if (settings.Files.Count == 0)
            {
                Console.WriteLine("At least one DME or DM file must be provided as an argument");
                return false;
            }

            return true;
        }
    }
}

using System;
using System.IO;
using Microsoft.Extensions.FileSystemGlobbing;

namespace header_updater
{
    class Program
    {
        static void Main(string[] args)
        {
            var printPathsOnly = true;
            string header = "// Copyright (c) 2020 some person\n";
            string rootDirectory = @"my/root/directory/path";

            var matcher = new Matcher();
            matcher.AddInclude("**/*.md");
            matcher.AddInclude("**/*.ts");
            matcher.AddInclude("**/*.js");
            matcher.AddInclude("**/*.c");
            matcher.AddInclude("**/*.h");
            matcher.AddInclude("**/*.hpp");
            matcher.AddInclude("**/*.cpp");
            matcher.AddExclude("**/node_modules/");
            matcher.AddExclude("**/googletest/");
            var results = matcher.GetResultsInFullPath(rootDirectory);

            foreach (var filePath in results)
            {
                if (printPathsOnly == false)
                {
                    var content = File.ReadAllText(filePath);
                    File.WriteAllText(filePath, header + content);
                }
                Console.WriteLine(filePath);
            }
        }
    }
}

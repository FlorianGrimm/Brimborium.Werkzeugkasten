using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Brimborium.Werkzeugkasten.Build;
public class Program {
    public static void Main(string[] args) {
        var sourceSolutionPath = GetSolutionPath();
        Console.WriteLine(sourceSolutionPath);
        // C:\github.com\FlorianGrimm\Brimborium.Werkzeugkasten
        // C:\github.com\FlorianGrimm\Brimborium.Werkzeugkasten\Brimborium.Werkzeugkasten.Powershell\PowerShellModule\Brimborium.Werkzeugkasten.psd1

        // C:\github.com\FlorianGrimm\Brimborium.Werkzeugkasten\Brimborium.Werkzeugkasten.Powershell\PowerShellModule\Brimborium.Werkzeugkasten.psd1
        var sourceBWPowershell = System.IO.Path.Combine(sourceSolutionPath, @"Brimborium.Werkzeugkasten.Powershell\");
        var sourceBWPowershell2 = System.IO.Path.Combine(sourceSolutionPath, @"Brimborium.Werkzeugkasten.Powershell\PowerShellModule\Brimborium.Werkzeugkasten.psd1");
        var sourceBrimboriumWerkzeugkasten_psd1 = System.IO.Path.Combine(sourceSolutionPath, @"Brimborium.Werkzeugkasten.Powershell\PowerShellModule\Brimborium.Werkzeugkasten.psd1");
        Console.WriteLine(@"C:\github.com\FlorianGrimm\Brimborium.Werkzeugkasten\Brimborium.Werkzeugkasten.Powershell\PowerShellModule\Brimborium.Werkzeugkasten.psd1");
        Console.WriteLine(sourceBrimboriumWerkzeugkasten_psd1);

        var contentBrimboriumWerkzeugkasten_psd1 = System.IO.File.ReadAllText(sourceBrimboriumWerkzeugkasten_psd1);

        //contentBrimboriumWerkzeugkasten_psd1
        var reVersion = new System.Text.RegularExpressions.Regex("(ModuleVersion[ ]*[=][ ]*['])([.0-9]+)(['])", System.Text.RegularExpressions.RegexOptions.Multiline);
        var matchVersion = reVersion.Match(contentBrimboriumWerkzeugkasten_psd1);
        var version = matchVersion.Success ? matchVersion.Groups[2].Value : "1.0.0";

        var targetPathUserProfile = System.Environment.GetEnvironmentVariable("USERPROFILE");
        if (string.IsNullOrEmpty(targetPathUserProfile)) { throw new Exception("USERPROFILE"); }

        // Copy to Windows PowerShell
        {
            var sourceLibraryPath = System.IO.Path.Combine(sourceSolutionPath, @"Brimborium.Werkzeugkasten.Powershell\bin\Debug\net472");
            Console.WriteLine(sourceLibraryPath);

            var sourcePowerShellModulePath = System.IO.Path.Combine(sourceSolutionPath, @"Brimborium.Werkzeugkasten.Powershell\PowerShellModule");
            Console.WriteLine(sourcePowerShellModulePath);

            var targetPathModule = System.IO.Path.Combine(targetPathUserProfile, @"Documents\WindowsPowerShell\Modules\Brimborium.Werkzeugkasten");
            Console.WriteLine(targetPathModule);
            System.IO.Directory.CreateDirectory(targetPathModule);

            copy(sourceLibraryPath, targetPathModule);
            copy(sourcePowerShellModulePath, targetPathModule);
        }

        // Copy to PowerShell 7
        {
            var sourceLibraryPath = System.IO.Path.Combine(sourceSolutionPath, @"Brimborium.Werkzeugkasten.Powershell\bin\Debug\net8.0");
            Console.WriteLine(sourceLibraryPath);

            var sourcePowerShellModulePath = System.IO.Path.Combine(sourceSolutionPath, @"Brimborium.Werkzeugkasten.Powershell\PowerShellModule");
            Console.WriteLine(sourcePowerShellModulePath);

            var targetPathModule = System.IO.Path.Combine(targetPathUserProfile, $@"Documents\PowerShell\Modules\Brimborium.Werkzeugkasten\{version}");
            Console.WriteLine(targetPathModule);
            System.IO.Directory.CreateDirectory(targetPathModule);

            copy(sourceLibraryPath, targetPathModule);
            copy(sourcePowerShellModulePath, targetPathModule);
        }

        // Build help with platyps

        {
            var process = new Process();
            process.StartInfo.FileName = @"C:\Program Files\PowerShell\7\pwsh.exe";
            process.StartInfo.ArgumentList.Add("-File");
            process.StartInfo.ArgumentList.Add(System.IO.Path.Combine(sourceSolutionPath, @"Brimborium.Werkzeugkasten.Build\build-help.ps1"));
            process.StartInfo.WorkingDirectory = System.IO.Path.Combine(sourceSolutionPath, @"Brimborium.Werkzeugkasten.Powershell");
            process.Start();
            process.WaitForExit();
            var exitCode = process.ExitCode;
            if (exitCode != 0) {
                System.Console.Error.WriteLine("build-help.ps1 failed");
            }

            System.IO.File.Copy(
                System.IO.Path.Combine(sourceSolutionPath, @"Brimborium.Werkzeugkasten.Powershell\PowershellHelp\Brimborium.Werkzeugkasten.Powershell.dll-Help.xml"),
                System.IO.Path.Combine(targetPathUserProfile, @"Documents\WindowsPowerShell\Modules\Brimborium.Werkzeugkasten\Brimborium.Werkzeugkasten.Powershell.dll-Help.xml"),
                true);
            System.IO.File.Copy(
                System.IO.Path.Combine(sourceSolutionPath, @"Brimborium.Werkzeugkasten.Powershell\PowershellHelp\Brimborium.Werkzeugkasten.Powershell.dll-Help.xml"),
                System.IO.Path.Combine(targetPathUserProfile, $@"Documents\PowerShell\Modules\Brimborium.Werkzeugkasten\{version}\Brimborium.Werkzeugkasten.Powershell.dll-Help.xml"),
                true);
        }

    }

    private static string GetSolutionPath([CallerFilePath] string? thisPath = default) {
        return System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(thisPath))!;
    }

    private static void copy(string sourcePath, string targetPath) {
        var listSource = new DirectoryInfo(sourcePath)
            .EnumerateFileSystemInfos("*.*", System.IO.SearchOption.AllDirectories)
            .ToList();
        foreach (var sourceFileSystemInfo in listSource) {
            var relativePath = sourceFileSystemInfo.FullName.Substring(sourcePath.Length + 1);
            var targetFilePath = System.IO.Path.Combine(targetPath, relativePath);
            if (sourceFileSystemInfo is System.IO.DirectoryInfo directoryInfo) {
                System.IO.Directory.CreateDirectory(targetFilePath);
            } else if (sourceFileSystemInfo is System.IO.FileInfo fileInfo) {
                //System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(targetFilePath)!);
                System.IO.File.Copy(fileInfo.FullName, targetFilePath, true);
            }
        }
    }
}

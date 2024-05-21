using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Brimborium.Werkzeugkasten.Powershell.Test;
public static class PowershellUtility {
    public static void ExecutePowershell(string fileName) {
        ExecutePowershellCore(fileName);
        ExecuteWindowsPowershell(fileName);
    }

    public static void ExecuteWindowsPowershell(string fileName) {
        var exePath = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";
        Execute("WPS", exePath, fileName);
    }

    public static void ExecutePowershellCore(string fileName) {
        var exePath = @"C:\Program Files\PowerShell\7\pwsh.exe";
        Execute("PWSH", exePath, fileName);
    }

    private static void Execute(string mode,string exePath, string fileName) {
        var projectPath = GetProjectPath();
        var process = new Process();
        process.StartInfo.WorkingDirectory = projectPath;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = false;
        process.StartInfo.FileName = exePath;
        process.StartInfo.ArgumentList.Add("-File");
        var filenamePS1 = System.IO.Path.Combine(projectPath, fileName);
        
        if (!System.IO.File.Exists(filenamePS1)) { throw new Exception($"{fileName} not found."); }

        process.StartInfo.ArgumentList.Add(filenamePS1);

        StringBuilder sbOutput = new StringBuilder();
        process.StartInfo.RedirectStandardOutput = true;
        process.OutputDataReceived += delegate (object sender, DataReceivedEventArgs e) {
            if (string.IsNullOrEmpty(e.Data)) { return; }
            //sbOutput ??= new StringBuilder();
            var text = e.Data.Replace("[33;1m", "").Replace("[0m", "");
            sbOutput.AppendLine(text);
        };

        StringBuilder sbError = new StringBuilder();
        process.StartInfo.RedirectStandardError = true;
        process.ErrorDataReceived += delegate (object sender, DataReceivedEventArgs e) {
            if (string.IsNullOrEmpty(e.Data)) { return; }
            var text = e.Data; //.Replace("[33;1m", "").Replace("[0m", "");
            sbOutput.AppendLine(text);
        };

        process.Start();
        if (process is null) { throw new Exception("process is null"); }
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit();
        var exitCode = process.ExitCode;
        if (exitCode != 0) { throw new Exception($"exitcode = {exitCode}"); }
        if (sbError.Length > 0) {
            System.IO.File.WriteAllText($"{filenamePS1}.{mode}.err.txt", sbError.ToString());
            throw new Exception(sbError.ToString()); 
        }
        var outFilePath = $"{filenamePS1}.{mode}.out.txt";
        if (System.IO.File.Exists(outFilePath)) {
            var content = System.IO.File.ReadAllText(outFilePath);
            Assert.Equal(content, sbOutput.ToString());
        } else { 
            System.IO.File.WriteAllText(outFilePath, sbOutput.ToString());
        }
    }

    private static string? _ProjectPath;
    private static string GetProjectPath([CallerFilePath] string? thisPath = default) {
        return _ProjectPath ??= (System.IO.Path.GetDirectoryName(thisPath))!;
    }
}


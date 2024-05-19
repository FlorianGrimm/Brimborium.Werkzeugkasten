namespace Brimborium.Werkzeugkasten.Powershell.VersionUtility {
    internal class Program {
        static void Main(string[] args) {
            var dependencyContext = Microsoft.Extensions.DependencyModel.DependencyContext.Default;
            var runtimeLibraries = dependencyContext.RuntimeLibraries;
            foreach (var runtimeLibrary in runtimeLibraries) {
                if (string.Equals(runtimeLibrary.Name, "Brimborium.Werkzeugkasten.Powershell.VersionUtility", StringComparison.Ordinal)) {
                    continue;
                }

                Console.WriteLine($"RuntimeLibrary: {runtimeLibrary.Name}");
                foreach (var group in runtimeLibrary.RuntimeAssemblyGroups) {
                    // Console.WriteLine($"  RuntimeAssemblyGroup: {group.AssetPaths}");
                    foreach (var runtimeFile in group.RuntimeFiles) {
                        Console.WriteLine($"    RuntimeFile.Path: {runtimeFile.Path}");
                    }
                    //foreach (var path in group.RuntimeAssemblyPaths) {
                    //    Console.WriteLine($"    RuntimeAssemblyPath: {path}");
                    //}
                }
            }
        }
    }
}

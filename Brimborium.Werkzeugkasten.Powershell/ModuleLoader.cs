namespace Brimborium.Werkzeugkasten;

public sealed class ModuleLoader : IModuleAssemblyInitializer, IModuleAssemblyCleanup {

    private static readonly Dictionary<string, Assembly> _AssemblyByName = new Dictionary<string, Assembly>(StringComparer.OrdinalIgnoreCase);
    private static readonly Dictionary<string, AssemblyName> _AssemblyNameByName = new Dictionary<string, AssemblyName>(StringComparer.OrdinalIgnoreCase);
    private static readonly Dictionary<string, string> _FileNameByAssemblyName = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

    private static bool _Wired = false;
    private static bool _Removed = false;

    public static void Wire() {
        if (_Wired) {
            return;
        } else {
            _Wired = true;
        }

#if Log
        System.Console.WriteLine("EnsureLoaded");
#endif
        var thisAssembly = typeof(ModuleLoader).Assembly;

        var location = System.IO.Path.GetDirectoryName(thisAssembly.Location);
        if (!string.IsNullOrEmpty(location)) {
            foreach (var f in System.IO.Directory.EnumerateFiles(location, "*.dll")) {
                var assemblyName = System.Reflection.AssemblyName.GetAssemblyName(f);
                _AssemblyNameByName[assemblyName.FullName] = assemblyName;
                _FileNameByAssemblyName[assemblyName.FullName] = f;
                if (assemblyName.Name is not null) {
                    _AssemblyNameByName[assemblyName.Name] = assemblyName;
                    _FileNameByAssemblyName[assemblyName.Name] = f;
                }
            }
        }
        System.AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
    }

    private static System.Reflection.Assembly? CurrentDomain_AssemblyResolve(object? sender, ResolveEventArgs args) {
        var argsName = args.Name;
#if Log
        System.Console.Out.WriteLine($"try to resolve {argsName}");
#endif
        {
            if (_AssemblyByName.TryGetValue(argsName, out var assembly)) {
                return assembly;
            }
        }
        {
            if (_AssemblyNameByName.TryGetValue(argsName, out var assemblyName)) {
                if (System.Reflection.Assembly.Load(assemblyName) is { } assembly) {
                    _AssemblyByName[argsName] = assembly;
                    if (assembly.FullName is { Length: > 0 } fullName) {
                        _AssemblyByName[fullName] = assembly;
                    }
                    return assembly;
                }
            }
        }
        var argsAssemblyName = new AssemblyName(argsName);
        if (argsAssemblyName.Name is { Length: > 0 } argsAssemblyName_Name) {
            if (_AssemblyNameByName.TryGetValue(argsAssemblyName_Name, out var assemblyName)) {
                if (System.Reflection.Assembly.Load(assemblyName) is { } assembly) {
                    _AssemblyByName[argsName] = assembly;
                    if (assembly.FullName is { Length: > 0 } fullName) {
                        _AssemblyByName[fullName] = assembly;
                    }
                    return assembly;
                }
            }

            if (_FileNameByAssemblyName.TryGetValue(argsAssemblyName_Name, out var filename)) {
                if (System.Reflection.Assembly.LoadFrom(filename) is { } assembly) {
                    _AssemblyByName[argsName] = assembly;
                    if (assembly.FullName is { Length: > 0 } fullName) {
                        _AssemblyByName[fullName] = assembly;
                    }
                    return assembly;
                }
            }
        }
#if Log
        System.Console.Out.WriteLine($"cannot resolve {argsName} nor {argsAssemblyName.Name}");
#endif
        return null!;
    }

    // IModuleAssemblyInitializer
    public void OnImport() {
        Wire();
    }

    // IModuleAssemblyCleanup
    public void OnRemove(PSModuleInfo psModuleInfo) {
        if (_Removed) {
            return;
        } else {
            _Removed = true;
        }
        System.AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
    }
}


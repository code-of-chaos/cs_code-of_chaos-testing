// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.CodeAnalysis;
using System.Reflection;

namespace CodeOfChaos.Testing;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public static class Extensions {
    public static PortableExecutableReference GetPortableExecutableReference(this Assembly assembly) => MetadataReference.CreateFromFile(assembly.Location);
    public static PortableExecutableReference GetPortableExecutableReference(this Type type) => MetadataReference.CreateFromFile(type.Assembly.Location);
}

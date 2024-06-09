using System.Diagnostics.CodeAnalysis;

namespace Aminoko.TemplateGen.Infrastructure;

public class CaseInsensitiveEqualityComparer : IEqualityComparer<string>
{
    public bool Equals(string? x, string? y)
    {
        return string.Equals(x, y, StringComparison.OrdinalIgnoreCase);
    }

    public int GetHashCode([DisallowNull] string obj)
    {
        return obj.ToLowerInvariant().GetHashCode();
    }
}

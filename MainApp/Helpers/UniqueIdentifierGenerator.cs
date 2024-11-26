using MainApp.Factories;
using MainApp.Models;
using System.Diagnostics;

namespace MainApp.Helpers;

public static class UniqueIdentifierGenerator
{
    public static string GenerateUniqueId()
    {
        try
        {
            return Guid.NewGuid().ToString();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }
}

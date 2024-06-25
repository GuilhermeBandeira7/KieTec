namespace Kietec.Api;

public static class ApiConfiguration
{
    public const string UserId = "user@kietec.io";
    public static string ConnectionString { get; set; } = string.Empty;
    public static string CorsPolicyName = "wasm";
}
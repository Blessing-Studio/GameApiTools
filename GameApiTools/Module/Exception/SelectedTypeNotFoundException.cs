namespace GameApiTools.Module.Exception;

/// <summary>
/// 未找到选择api类型的异常
/// </summary>
public class SelectedTypeNotFoundException : System.Exception
{
    public SelectedTypeNotFoundException(string message) : base(message) => Console.WriteLine(message);
}
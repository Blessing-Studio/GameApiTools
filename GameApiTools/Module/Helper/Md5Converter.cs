using System.Security.Cryptography;
using System.Text;

namespace GameApiTools.Module.Helper;

/// <summary>
/// 为动态密钥提供器提供Md5算法
/// </summary>
public abstract class Md5Converter
{
    /// <summary>
    /// 获取字符串的MD5计算结果
    /// </summary>
    /// <param name="source">源字符串</param>
    /// <returns>计算的结果</returns>
    public static string GetComputedMd5(string source)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] result = md5.ComputeHash(Encoding.UTF8.GetBytes(source));

            StringBuilder builder = new();

            foreach (byte b in result)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
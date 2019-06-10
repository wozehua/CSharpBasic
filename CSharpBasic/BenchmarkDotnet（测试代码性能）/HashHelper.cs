using System;
using System.Security.Cryptography;
using System.Text;

namespace BenchmarkDotnet_测试代码性能_
{
    public static class HashHelper
    {
        public static string GetMD5(string input)
        {
            if(input==null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            using (var md5=MD5.Create())
            {
                //将input 转换成UTF-8编码字节数组
                var buffer = Encoding.UTF8.GetBytes(input);
                //计算指定字节数组的哈希值。
                var hashResult = md5.ComputeHash(buffer);
                return BitConverter.ToString(hashResult).Replace("-", string.Empty);
            }
        }

        public static string GetSHA1(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }
            using (var sha=SHA1.Create())
            {
                var buffer = Encoding.UTF8.GetBytes(input);
                var hashResult = sha.ComputeHash(buffer);
                return Convert.ToString(hashResult).Replace("-", string.Empty);

            }
        }

    }
}

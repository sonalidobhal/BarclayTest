using System;
using System.Reflection;
using System.Text.RegularExpressions;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Type typeInstance = typeof(FileDetails);
            var firstArgument = !string.IsNullOrEmpty(args[0]) ? Regex.Replace(args[0], "[^0-9a-zA-Z]+", "") : string.Empty;
            object classInstance = Activator.CreateInstance(typeInstance, null);
            foreach (MethodInfo methodInfo in typeInstance.GetMethods())
            {
                if (methodInfo.Name.ToLower().StartsWith(firstArgument) || methodInfo.Name.ToLower().Equals(firstArgument))
                {
                    ParameterInfo[] parameterInfo = methodInfo.GetParameters();
                    if (parameterInfo.Length == 0)
                    {
                        // there is no parameter we can call with 'null'
                        Console.WriteLine(methodInfo.Invoke(classInstance, null));
                    }
                    else
                    {
                        Console.WriteLine(methodInfo.Invoke(classInstance, new object[] { args[1] }));
                    }
                }
            }
        }
    }
}

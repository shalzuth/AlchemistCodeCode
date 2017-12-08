using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Mono.Cecil;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Ast;

namespace DataExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Wiki.Updater.Update();
            // todo - add getting Assembly-CSharp.dll dynamically
            var assemblyDefinition = AssemblyDefinition.ReadAssembly(@"Assembly-CSharp.dll");
            var types = assemblyDefinition.MainModule.Types.ToList().FindAll(t => t.Name.StartsWith("Req"));
            foreach (var type in types)
            {
                var decompiler = new AstBuilder(new DecompilerContext(type.Module));
                decompiler.AddType(type);
                var output = new StringWriter();
                decompiler.GenerateCode(new PlainTextOutput(output));
                var code = output.ToString();
                code = code.Replace("Network.", "Networking.");
                code = code.Replace("Mathf.", "Math.");
                code = code.Replace("using UnityEngine;\r\n", "");
                code = code.Replace("\r\nnamespace SRPG", "using SRPG;\r\n\r\nnamespace AlchemistCodeCode.Network.Requests");
                //code = code.Replace("\r\nnamespace SRPG", "\r\n\r\nnamespace AlchemistCodeCode.Network.Requests");
                code = code.Replace("SystemInfo.deviceModel", "\"samsung SM-E7000\"");
                code = code.Replace(", Networking.ResponseCallback response = null", "");
                code = code.Replace(", Networking.ResponseCallback response", "");
                code = code.Replace("Networking.ResponseCallback response, ", "");
                code = code.Replace("Networking.ResponseCallback response", "");
                code = code.Replace(", response", "");
                code = code.Replace("\r\n			this.callback = response;", "");
                code = code.Replace("TimeManager.ServerTime.ToYMD()", "int.Parse(DateTime.Now.ToString(\"yyMMdd\"))");
                code = code.Replace("GameUtility.ConvertLanguageToISO639(language)", "language");
                code = code.Replace("MonoSingleton<", "");
                code = code.Replace(">.Instance", ".Instance");
                //Console.WriteLine(code);
                //File.WriteAllText(@"..\AlchemistCodeCode\Network\Requests\" + type.Name + ".cs", code);
            }
        }
    }
}

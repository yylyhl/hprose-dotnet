#if !NETCOREAPP2_0
[assembly: System.CLSCompliant(true)]
[assembly: System.Reflection.AssemblyCompany("http://www.hprose.com")]
[assembly: System.Reflection.AssemblyCopyright("\x00a9 http://www.hprose.com, All rights reserved.")]
#if (dotNET10 || dotNET11 || dotNETCF10) && !MONO
[assembly: System.Reflection.AssemblyKeyFile("HproseKeys.snk")]
#endif
[assembly: System.Reflection.AssemblyProduct(Hprose.AssemblyInfo.Name + " " + Hprose.AssemblyInfo.Version + " for " + Hprose.AssemblyInfo.dotNET_Name)]
[assembly: System.Reflection.AssemblyInformationalVersion(Hprose.AssemblyInfo.Version + "." + Hprose.AssemblyInfo.BuildNumber + ".0")]
[assembly: System.Reflection.AssemblyTitle(Hprose.AssemblyInfo.FileName)]
[assembly: System.Reflection.AssemblyDescription(Hprose.AssemblyInfo.FileName)]
[assembly: System.Reflection.AssemblyDefaultAlias(Hprose.AssemblyInfo.FileName)]
[assembly: System.Reflection.AssemblyVersion(Hprose.AssemblyInfo.dotNET_Version)]
#if !Smartphone
[assembly: System.Reflection.AssemblyFileVersion(Hprose.AssemblyInfo.dotNET_Version)]
#endif
#endif
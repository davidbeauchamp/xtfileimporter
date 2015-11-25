using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Resources;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("File Importer for xTuple")]
[assembly: AssemblyDescription("Imports/Exports files from xTuples document archive")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("xTuple")]
[assembly: AssemblyProduct("xtfileimporter")]
[assembly: AssemblyCopyright("2013-2015 David Beauchamp")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("b3a47086-6609-4589-89cc-38b059d15a0d")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("1.0.0.31")]
[assembly: AssemblyFileVersion("1.0.0.31")]
[assembly: NeutralResourcesLanguageAttribute("en")]

// modified from http://geekswithblogs.net/dbrown/archive/2009/04/06/easy-access-to-assemblyinfo.cs-attributes.aspx
// provides easy access to the above attributes. 
// Why I have to do this myself I will never understand.
public static class AssemblyInfo
{
    public static string Title
    {
        get
        {
            var attr = GetAssemblyAttribute<AssemblyTitleAttribute>();
            if (attr != null)
                return attr.Title;
            return string.Empty;
        }
    }

    public static string Company
    {
        get
        {
            var attr = GetAssemblyAttribute<AssemblyCompanyAttribute>();
            if (attr != null)
                return attr.Company;
            return string.Empty;
        }
    }

    public static string Product
    {
        get
        {
            var attr = GetAssemblyAttribute<AssemblyProductAttribute>();
            if (attr != null)
                return attr.Product;
            return string.Empty;
        }
    }

    public static string Description
    {
        get
        {
            var attr = GetAssemblyAttribute<AssemblyDescriptionAttribute>();
            if (attr != null)
                return attr.Description;
            return string.Empty;
        }
    }

    public static string Copyright
    {
        get
        {
            var attr = GetAssemblyAttribute<AssemblyCopyrightAttribute>();
            if (attr != null)
                return attr.Copyright;
            return string.Empty;
        }
    }

    public static string Version
    {
        get
        {
            var attr = GetAssemblyAttribute<AssemblyFileVersionAttribute>();
            if (attr != null)
                return attr.Version;
            return string.Empty;
        }
    }

    /// <summary>
    /// This method uses reflection to read the compiled date out of the
    /// executable header. 
    /// Yeah.
    /// </summary>
    /// <returns>DateTime</returns>
    public static System.DateTime getBuildDate()
    {
        string filePath = System.Reflection.Assembly.GetCallingAssembly().Location;
        const int c_PeHeaderOffset = 60;
        const int c_LinkerTimestampOffset = 8;
        byte[] b = new byte[2048];
        System.IO.Stream s = null;

        try
        {
            s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            s.Read(b, 0, 2048);
        }
        catch (System.Exception) { }
        finally
        {
            if (s != null)
            {
                s.Close();
            }
        }

        int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
        int secondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
        System.DateTime dt = new System.DateTime(1970, 1, 1, 0, 0, 0);
        dt = dt.AddSeconds(secondsSince1970);
        dt = dt.AddHours(System.TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
        return dt;
    }
    
    private static T GetAssemblyAttribute<T>() where T : System.Attribute
    {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(T), true);
        if (attributes == null || attributes.Length == 0) return null;
        return (T)attributes[0];
    }
}

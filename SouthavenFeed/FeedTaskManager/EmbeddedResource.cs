using System.IO;

namespace SouthavenFeed.FeedTaskManager
{
    /// <summary>
    /// Gets an embedded resouce SQL file from the assembly and
    /// returns the raw string
    /// 
    /// references and copied from here:
    /// https://jopinblog.wordpress.com/2007/11/12/embedded-resource-queries-or-how-to-manage-sql-code-in-your-net-projects/
    /// </summary>
    public class EmbeddedResource
    {
        private EmbeddedResource()
        {
        }

        public static StreamReader GetStream(System.Reflection.Assembly assembly, string name)
        {
            foreach (string resName in assembly.GetManifestResourceNames())
            {
                if (resName.EndsWith(name))
                {
                    return new System.IO.StreamReader(assembly.GetManifestResourceStream(resName));
                }
            }
            return null;
        }

        public static string GetString(System.Reflection.Assembly assembly, string name)
        {
            System.IO.StreamReader sr = EmbeddedResource.GetStream(assembly, name);
            string data = sr.ReadToEnd();
            sr.Close();
            return data;
        }

        public static string GetString(string name)
        {
            return EmbeddedResource.GetString(typeof(EmbeddedResource).Assembly, name);
        }
    }
}

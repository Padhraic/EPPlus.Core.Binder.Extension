using System;
using System.IO;

namespace Binder.Extension.Test
{
    public static class TestHelper
    {
        /// <summary>
        /// Gets the empty folder.
        /// The folder will be contained inside the applicat data folder.
        /// </summary>
        /// <value>
        /// The fully qualified path of the empty folder.
        /// </value>
        public static string EmptyFolder
        {
            get
            {
                var guid = Guid.NewGuid().ToString("N");
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData,
                    Environment.SpecialFolderOption.Create),"EPPlus_Core_Binder",guid);
                Directory.CreateDirectory(path);
                return path;
            }
        }
        public static string NonexistentFolder
        {
            get
            {
                var guid = Guid.NewGuid().ToString("N");
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData,
                    Environment.SpecialFolderOption.Create), "EPPlus_Core_Binder", guid);
                return path;
            }
        }

        public static string TestAssetsFolder => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestAssets");



        

        public static byte[] ReadBytesArrayFromStream(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream()) {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0) {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }


    }
}
﻿#region Disclaimer / License

// Copyright (C) 2011, Jackie Ng
// https://github.com/jumpinjackie/mapguide-maestro
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
//

#endregion Disclaimer / License

using ICSharpCode.Core;
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace LocalConfigure
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var path = Path.Combine(FileUtility.ApplicationRootPath, "Platform.ini");
            var providersPath = Path.Combine(FileUtility.ApplicationRootPath, "ConnectionProviders.xml");
            var addInPath = Path.Combine(FileUtility.ApplicationRootPath, "AddIns\\Local");
            if (!File.Exists(path))
            {
                var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                StringBuilder sb = new StringBuilder(Properties.Resources.Platform);
                sb.Replace("%INSTALLDIR%", FileUtility.ApplicationRootPath);
                sb.Replace("%APPDATA%", appData);
                sb.Replace("%ADDINDIR%", addInPath);

                File.WriteAllText(path, sb.ToString());
                Console.WriteLine("Platform.ini created");
            }
            else
            {
                Console.WriteLine("Platform.ini already exists. Nothing to do");
            }

            if (File.Exists(providersPath))
            {
                var doc = new XmlDocument();
                doc.Load(providersPath);
                var nodes = doc.GetElementsByTagName("Name");
                foreach (XmlNode n in nodes)
                {
                    if (n.InnerText == "Maestro.Local")
                    {
                        Console.WriteLine("ConnectionProviders.xml already has Maestro.Local registered. Nothing to do");
                        return;
                    }
                }

                var root = doc.DocumentElement;
                root.InnerXml += Properties.Resources.ProviderEntry.Replace("%ADDINDIR%", addInPath);

                doc.Save(providersPath);
                Console.WriteLine("Maestro.Local registered in ConnectionProviders.xml");
            }
        }
    }
}
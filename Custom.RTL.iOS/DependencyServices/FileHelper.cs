﻿using System;
using System.IO;
using Custom.RTL.Common;
using Custom.RTL.DependencyServices;
using Custom.RTL.iOS.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace Custom.RTL.iOS.DependencyServices
{
    public class FileHelper : IFileHelper
    {
        public bool? IsPreferredLanguageArabic()
        {
            bool status = false;
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(docFolder, "..", "Library", "language.txt");
            if (!File.Exists(filePath))
            {
                return null;
            }

            try
            {
                string content = File.ReadAllText(filePath);
                Boolean.TryParse(content, out status);
                return status;
            }
            catch (Exception ex)
            {
                CommonHelper.ErrorLog(ex);
                return status;
            }
        }

        public void SaveUserLanguagePreference(bool status)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(docFolder, "..", "Library", "language.txt");
            File.WriteAllText(filePath, status ? "true" : "false");
        }
    }
}

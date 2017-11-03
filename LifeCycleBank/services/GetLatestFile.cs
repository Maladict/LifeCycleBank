﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LifeCycleBank.services
{
    class GetLatestFile
    {
        public static string GetPathToLatestFile()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "bankdata");
            var directory = new DirectoryInfo(path);
            var latestFile = directory.GetFiles()
                               .OrderByDescending(f => GetDateFromFileName(f.Name))
                               .First();

            return latestFile.FullName;
        }

        private static DateTime GetDateFromFileName(string fileName)
        {
            DateTime date;
           DateTime.TryParseExact(GetFileNameDate(fileName),
                  "yyyyMMdd-HHmm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
               
                return date;
            
        }

        private static string GetFileNameDate(string fileName)
        {
            var name = fileName.Substring(0, fileName.IndexOf(".txt"));
            return name;
        }
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Windows;

namespace Project1
{
    internal class JasOn
    {
        public JasOn(DbSet<Employee> data)

        {
            using (FileStream fs = new FileStream("employee.json", FileMode.OpenOrCreate))
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                string employee = JsonSerializer.Serialize(data, options);
                StreamWriter file = File.CreateText("../../../Reports\\Report.json");
                file.WriteLine(employee);
                file.Close();

                MessageBox.Show("Отчет Сохранен");
            }
        }
    }
}
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project1
{
    internal class Excel
    {
        public Excel(DbSet<Employee> data)
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                //Set some properties of the Excel document
                excelPackage.Workbook.Properties.Author = "God of Politex";
                excelPackage.Workbook.Properties.Title = "Отчет о сотруднкиах";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                //Create the WorkSheet
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Отчет");

                //Add some text to cell A1
                worksheet.Cells["A1"].Value = "ID";
                worksheet.Cells["B1"].Value = "Персональный ID";
                worksheet.Cells["C1"].Value = "Фамилия";
                worksheet.Cells["D1"].Value = "Имя";
                worksheet.Cells["E1"].Value = "Отчество";
                worksheet.Cells["F1"].Value = "Телефон";
                worksheet.Cells["G1"].Value = "Дата рождения";
                worksheet.Cells["H1"].Value = "Отдел";
                int count = 2;
                foreach (Employee employee in data)
                {
                    worksheet.Cells[count, 1].Value = employee.Id;
                    worksheet.Cells[count, 2].Value = employee.PersonalId;
                    worksheet.Cells[count, 3].Value = employee.LastName;
                    worksheet.Cells[count, 4].Value = employee.Name;
                    worksheet.Cells[count, 5].Value = employee.Patronymic;
                    worksheet.Cells[count, 6].Value = employee.Phone;
                    worksheet.Cells[count, 7].Value = employee.DateBirth;
                    worksheet.Cells[count, 8].Value = employee.Department;
                    count++;
                }
                //Save your file
                FileInfo fi = new FileInfo("../../../Reports\\Report.xlsx");
                excelPackage.SaveAs(fi);

                MessageBox.Show("Отчет Сохранен");
            }
        }
    }
}

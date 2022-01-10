using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Turnike
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            var file = new FileInfo(@"C:\Users\ALTAMIRA\Desktop\Turnike1.xlsx");

            List<PersonModel> peopleFromExcel = await LoadExcelFile(file);

            foreach (var p in peopleFromExcel)
            {
                Console.WriteLine($"{p.Name} {p.Type} {p.WorkTime}");
            }

            Console.WriteLine("---------------------------------------------------------------------------");

            var insanlar = peopleFromExcel.GroupBy(x => x.Name).ToList();
            foreach (var person in insanlar)
            {
                Thread thread = new Thread(() =>
                {
                    var totalPersonDuration = CalculateWorkDurationOfPerson(person.ToList());
                    Console.WriteLine(person.Key + " : " + totalPersonDuration);
                });
                thread.Start();
            }

        }

        private static async Task<List<PersonModel>> LoadExcelFile(FileInfo file)
        {
            List<PersonModel> output = new();
            using var package = new ExcelPackage(file);
            await package.LoadAsync(file);

            var ws = package.Workbook.Worksheets[0];
            int row = 3;
            int col = 1;
            while (string.IsNullOrWhiteSpace(ws.Cells[row, col].Value?.ToString())==false)
            {
                PersonModel p = new();
                p.Name = ws.Cells[row, col].Value.ToString();
                p.Type= ws.Cells[row, col+1].Value.ToString();
                p.WorkTime = DateTime.Parse(ws.Cells[row, col + 2].Value.ToString());
                output.Add(p);
                row += 1;
            }
            return output;
        }
        static /*double*/ TimeSpan CalculateWorkDurationOfPerson(List<PersonModel> actions)
        {
            DateTime lastEnter = new DateTime();
            //TimeSpan dateTime =new TimeSpan();
            //var totalWorkDuration = 0.0;
            TimeSpan total = new TimeSpan();
            var lastCheckedActionType = "Out";
            var today = new DateTime(2022, 1, 1, 0, 0, 0);  //normal şartlarda o günün tarihi baz alınacaktır. Örn:DateTime today = DateTime.Today;
            foreach (var action in actions)
            {
                if (today == action.WorkTime.Date)
                {
                    if (action.Type == "In")
                    {
                        lastEnter = action.WorkTime;
                    }
                    else if (action.Type == "Out" && lastCheckedActionType == "In")
                    {
                        /*var workDuration*/
                        TimeSpan dateTime = action.WorkTime - lastEnter;
                        /*totalWorkDuration*/
                        total += dateTime /*workDuration.TotalMinutes*/;
                    }
                    lastCheckedActionType = action.Type;
                }

            }
            return /*totalWorkDuration*/total;
        }
    }
}

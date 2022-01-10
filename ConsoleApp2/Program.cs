using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ExcelDataReader;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ExcelConverter
{
    class Program
    {

        static /*double*/ TimeSpan CalculateWorkDurationOfPerson(List<Person> actions)
        {
            DateTime lastEnter = new DateTime();
            //TimeSpan dateTime =new TimeSpan();
            //var totalWorkDuration = 0.0;
            TimeSpan total = new TimeSpan();
            var lastCheckedActionType = "Out";
            var today = new DateTime(2022, 1, 1, 0, 0, 0);  //normal şartlarda o günün tarihi baz alınacaktır. Örn:DateTime today = DateTime.Today;
            foreach (var action in actions)
            {
                if(today==action.WorkTime.Date)
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



        static void Main(string[] args)
        {
            //Dosyanın okunacağı dizin
            string filePath = @"C:\Users\ALTAMIRA\Desktop\Turnike1.xlsx";

            //Dosyayı okuyacağımı ve gerekli izinlerin ayarlanması.
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            //Encoding 1252 hatasını engellemek için;

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            IExcelDataReader excelReader;
            List<string> liste = new List<string>();
            int counter = 0;

            //Gönderdiğim dosya xls'mi xlsx formatında mı kontrol ediliyor.
            if (Path.GetExtension(filePath).ToUpper() == ".XLS")
            {
                //Reading from a binary Excel file ('97-2003 format; *.xls)
                excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            }
            else
            {
                //Reading from a OpenXml Excel file (2007 format; *.xlsx)
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            }

            /*yeni sürümlerde bu kaldırıldığı için kapatıldı.
            //Datasete atarken ilk satırın başlık olacağını belirtiyor.
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();*/

            //Veriler okunmaya başlıyor.
            while (excelReader.Read())
            {
                counter++;

                //ilk satır başlık olduğu için 2.satırdan okumaya başlıyorum.
                if (counter > 1)
                {
                    liste.Add(excelReader.GetString(0) + "/" + excelReader.GetString(1) + "/" + excelReader.GetDateTime(2));

                }
            }

            //Okuma bitiriliyor.
            excelReader.Close();
            List<Person> people = new List<Person>() { };
            //Veriler ekrana basılıyor.
            foreach (var item in liste)
            {

                string[] _Split = item.Split('/');
                //var parsedTime = DateTime.Parse(_Split[2]);
                people.Add(new Person() { Name = _Split[0], Type = _Split[1], WorkTime = DateTime.Parse(_Split[2]) });




            }
            //List<string> olditem = new List<string>();
            //foreach (var item in people)
            //{
            //    if(!olditem.Contains(item.Name))
            //    {
            //        var kisi = people.Where(x => x.Name == item.Name).FirstOrDefault(t => t.Type == "In");
            //        var giris = kisi.WorkTime;
            //        var kisi1 = people.Where(x => x.Name == item.Name).LastOrDefault(t => t.Type == "Out");
            //        var cikis = kisi1.WorkTime;
            //        var work = cikis - giris;
            //        Console.WriteLine(kisi.Name + " ilk giriş: " + giris + " son çıkış: " + cikis + " toplam çalışma saati: " + work);
            //        olditem.Add(item.Name);
            //    }


            //}
            //var result = people.GroupBy(s => new { s.Name,s.Type }).Select(gr => new
            //               {
            //                 Name = gr.Key.Name,
            //                 Type=gr.Key.Type,
            //                 In = gr.Min(g => g.WorkTime.TimeOfDay),
            //                 Out=gr.Max(gr=>gr.WorkTime.TimeOfDay)
            //}).OrderBy(x => x.Type).ToList();
            //foreach (var item in result)
            //{
            //    Console.WriteLine("{0} {1} {2} {3}",item.Name,item.Type,item.In,item.Out);

            //}




            var insanlar = people.GroupBy(x => x.Name).ToList();
            foreach (var person in insanlar)
            {
                Thread thread = new Thread(() =>
                 { 
                     var totalPersonDuration = CalculateWorkDurationOfPerson(person.ToList());
                     Console.WriteLine(person.Key + " : " + totalPersonDuration);
                 });
                thread.Start();
            }


            //List<Personnel> personnel = new List<Personnel>() { };
            //int sayac = 0;
            //int sayacc = 0;
            //foreach (var item in people)
            //{
            //    if (item.Type == "In")
            //    {
            //        var pers = personnel.Where(x => x.Name == item.Name).FirstOrDefault(t => t.Type == "In");
            //        if (pers == null || sayac != 0)
            //        {
            //            personnel.Add(new Personnel() { Name = item.Name, Type = item.Type, WorkTime = item.WorkTime });
            //            sayacc++;
            //            sayac = 0;
            //        }

            //    }
            //    else
            //    {
            //        var pers = personnel.Where(x => x.Name == item.Name).FirstOrDefault(t => t.Type == "Out");
            //        if (pers == null || sayacc != 0)
            //        {
            //            personnel.Add(new Personnel() { Name = item.Name, Type = item.Type, WorkTime = item.WorkTime });
            //            sayac++;
            //            sayacc = 0;

            //        }
            //    }
            //}

            //    foreach (var itemm in personnel)
            //    {
            //        Console.WriteLine("{0} - {1}", itemm.Name, itemm.WorkTime);
            //    }






            Console.ReadKey();


        }
    }
    public class Person
    {
        public Person()
        {
        }

        public Person(string name, string type, DateTime workTime)
        {
            Name = name;
            Type = type;
            WorkTime = workTime;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime WorkTime { get; set; }

    }
    public class Personnel
    {
        public Personnel()
        {
        }

        public Personnel(string namee, string typee, DateTime workTimee)
        {
            Name = namee;
            Type = typee;
            WorkTime = workTimee;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime WorkTime { get; set; }

    }
}

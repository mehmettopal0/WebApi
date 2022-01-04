using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ExcelDataReader;

namespace ExcelConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dosyanın okunacağı dizin
            string filePath = @"C:\Users\ALTAMIRA\Desktop\Turnike.xlsx";

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
                    liste.Add(excelReader.GetString(0)+"/"+excelReader.GetString(1)+"/"+excelReader.GetDateTime(2));
                    
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
                people.Add(new Person() { Name = _Split[0], Type = _Split[1] , WorkTime= DateTime.Parse(_Split[2]) });




            }
            List<string> olditem = new List<string>();
            foreach (var item in people)
            {
                if(!olditem.Contains(item.Name))
                {
                    var kisi = people.Where(x => x.Name == item.Name).FirstOrDefault(t => t.Type == "In");
                    var giris = kisi.WorkTime;
                    var kisi1 = people.Where(x => x.Name == item.Name).LastOrDefault(t => t.Type == "Out");
                    var cikis = kisi1.WorkTime;
                    var work = cikis - giris;
                    Console.WriteLine(kisi.Name + " ilk giriş: " + giris + " son çıkış: " + cikis + " toplam çalışma saati: " + work);
                    olditem.Add(item.Name);
                }

                
            }
            

            Console.ReadKey();
            
            
        }
    }
    public class Person
    {
        public Person()
        {
        }

        public Person(string name, string type,DateTime workTime)
        {
            Name = name;
            Type = type;
            WorkTime = workTime;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime WorkTime { get; set; }

    }
}

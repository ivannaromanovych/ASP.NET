using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _03_10_2019ExampleSemen
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient webClient = new WebClient();
            //webClient.DownloadFile(
            //    "https://r5---sn-vgqsknll.googlevideo.com/videoplayback?expire=1570137625&ei=uRGWXcniCsic4QTTibSYCQ&ip=23.82.80.71&id=o-AH1O5SN9cWBc354sBqUwBZBay9H-r8YFBLgvboksTCqU&itag=22&source=youtube&requiressl=yes&mm=31%2C26&mn=sn-vgqsknll%2Csn-tt1e7n7k&ms=au%2Conr&mv=m&mvi=4&pl=21&initcwndbps=281250&mime=video%2Fmp4&ratebypass=yes&dur=360.536&lmt=1509685350466369&mt=1570115942&fvip=5&fexp=23842630&c=WEB&sparams=expire%2Cei%2Cip%2Cid%2Citag%2Csource%2Crequiressl%2Cmime%2Cratebypass%2Cdur%2Clmt&sig=ALgxI2wwRgIhAMVODP79M9BmkKHBUwPflek-IlrcGHDJxc_PNTJxeQ3eAiEA8sGf27RODaBiS-ZXUiiNOGWT-wY8hlI3X-rXFcXcM-M%3D&lsparams=mm%2Cmn%2Cms%2Cmv%2Cmvi%2Cpl%2Cinitcwndbps&lsig=AHylml4wRgIhAJq15xT9xyx45V3oMaFVI2CYfdslXqLoD0JklGJR3lgcAiEAmY7oU598EuIO0fLqUqxE2dYb67SQ8tjrldN9tiX_6k0%3D&video_id=LlH2sPSPJnw&title=%F0%9F%8E%89+My+React+Course+is+Ready%21",
            //    "redhair_witch.mp4");
            //using (StreamWriter writer = new StreamWriter("site.html"))
            //{
            //    writer.Write(webClient.DownloadString("https://www.shutterstock.com/ru/search/orange+girl"));
            //}
            //Console.WriteLine(site);

            //string site = webClient.DownloadString("https://www.shutterstock.com/ru/search/orange+girl");
            //int i = 0;
            //foreach (Match m in Regex.Matches(site, @"(http(s?):)([/|.|\w|\s|-])*\.(?:jpg|gif|png)"))
            //{
            //    i++;
            //    webClient.DownloadFile(m.Value, @"Images\redhair_" + i + ".jpg");
            //}

            HttpWebRequest request = WebRequest.CreateHttp("https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5");
            request.Method = "GET";

            string data;
            WebResponse response = request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                data = reader.ReadToEnd();
            }
            Console.WriteLine(data);
            List<Currency> currencies = JsonConvert.DeserializeObject<List<Currency>>(data);
            Console.WriteLine("What do you want to do: 1 - buy currency, 2 - sale currency, 0 - exit");
            uint choice = uint.Parse(Console.ReadLine());
            while (choice != 0)
            {
                Console.WriteLine("Enter currency: 0 - USD, 1 - EUR, 2 - RUB, 3 - UAH");
                int cur = int.Parse(Console.ReadLine());
                double sum = 0;
                try
                {
                    Console.Write("Enter sum of your currency: ");
                    sum = double.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Enter sum like _,_");
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(currencies[cur].base_ccy + ": " + sum * currencies[cur].buy);
                        break;
                    case 2:
                        Console.WriteLine(currencies[cur].ccy + ": " + sum / currencies[cur].sale);
                        break;
                }
                Console.WriteLine("What do you want to do: 1 - buy UAH, 2 - sale UAH, 0 - exit");
                choice = uint.Parse(Console.ReadLine());
            }
            Console.WriteLine("Bye!!!");
            //string site = webClient.DownloadString("https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5");
            //Console.WriteLine(site);
            
        }
    }


}


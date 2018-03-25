using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace ConsoleApplication1
{

    class Program
    {
        public class dot
        {
            public string 機構名稱 { get; set; }
            public string 地址縣市別 { get; set; }
            public string 地址鄉鎮市區 { get; set; }
            public string 負責人姓名 { get; set; }
            public string 電話 { get; set; }
        }
        static void Main(string[] args)
        {
            var dot = Finddot();

            Showdot(dot);


        }
        public static List<dot> Finddot() 
        {
            List<dot> dots = new List<dot>();
            var xml = XElement.Load(@"2ba22002ce3cc736d4db3269451bdc29_export.xml");

            var dotsNode = xml.Descendants("row").ToList();

            dotsNode
                .Where(x=>!x.IsEmpty).ToList()
                .ForEach(dotNode =>
            {
                dot o =new dot();
                o.機構名稱= dotNode.Element("Col2").Value;
                o.地址縣市別= dotNode.Element("Col3").Value;
                o.地址鄉鎮市區 = dotNode.Element("Col4").Value;
                o.負責人姓名 = dotNode.Element("Col6").Value;
                o.電話 = dotNode.Element("Col8").Value;
                dots.Add(o);
            });
            return dots;
        }
        static void Showdot(List<dot> dots)
        {
            dots.ForEach(data =>
            {
                Console.WriteLine("機構名稱:{0} 地址縣市別:{1} 地址鄉鎮市區:{2} 負責人姓名:{3} 電話:{4}", data.機構名稱, data.地址縣市別, data.地址鄉鎮市區, data.負責人姓名, data.電話);
            });
            Console.ReadKey();
        }
    }
}

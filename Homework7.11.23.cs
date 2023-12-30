using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Homework31._10._23
{
    //4
    class Enterprise
    {
        string name;
        DateTime foundationDate;
        int nWorkers;
        public Enterprise(string name, DateTime foundationDate, int nWorkers)
        {
            this.name = name;
            this.foundationDate = foundationDate;
            this.nWorkers = nWorkers;
        }
        public string Name { get => name; set => name = value; }
        public DateTime FoundationDate { get => foundationDate; set => foundationDate = value; }
        public int NWorkers { get => nWorkers; set => nWorkers = value; }
        public override string ToString()
        {
            return string.Format($"name:{name}, foundationDate:{foundationDate.ToShortDateString()}, nWorkers:{nWorkers}");

        }

    }
    class ProccesEnterprise
    {
        public string[] GetInfo(Enterprise[] A)
        {
            string[] s = (from n in A
                         select n.ToString()).ToArray();
            return s;
        }
        public string[] GetCountWorkers(Enterprise[] A)
        {
            string[] s =  (from n in A
                          where n.NWorkers > 100
                          select n.Name).ToArray();
            return s;
                          
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {


            Enterprise[] enterprise =
            {
                new Enterprise("DevilStudio",new DateTime(2000,8,13),125),
                new Enterprise("Angel2Free",new DateTime(1988,4,22),1000),
                new Enterprise("GGG",new DateTime(2020,4,21),15),
                new Enterprise("GGG222222",new DateTime(2021,4,21),5),

            };

            ProccesEnterprise proccesEnterprise = new ProccesEnterprise();
            Console.WriteLine(string.Join("\n",proccesEnterprise.GetInfo(enterprise)));
            Console.WriteLine("-----------------");

            Console.WriteLine(string.Join("\n", proccesEnterprise.GetCountWorkers(enterprise)));
        }
    }
}

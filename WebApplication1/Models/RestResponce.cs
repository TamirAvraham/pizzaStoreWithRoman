using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ConsoleApp2
{
    public class RestResponce
    {
        public string ID { get; set; }
        public string Messge { get; set; }    
        public Dictionary<string, dynamic> Data { get; set; }
        public RestResponce(string iD, string messge, Dictionary<string, dynamic> data)
        {
            ID = iD;
            Messge = messge;
            Data = data;
        }
        //to string
        public override string ToString()
        {
            return $"Id:{ID},messge:{Messge},data:{Data}";
        }
    }
}

using System;
using Newtonsoft.Json;

namespace SftpConn
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("傳入參數：" + JsonConvert.SerializeObject(args));
            if(args.Length < 4){
                System.Console.WriteLine("請輸入 {host} {username} {password} {fileName}");
                return;
            }
            
            var host = args[0];
            var username = args[1];
            var password = args[2];
            var fileName = args[3];
            Console.WriteLine($" host:{host} \n username:{username} \n password:{password} \n fileName:{fileName}");

            SendFileToServer.Upload(host, username, password, fileName);
        }
    }
}

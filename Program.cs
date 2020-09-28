using System;
using System.IO;
using Newtonsoft.Json;
using Renci.SshNet;

namespace SftpConn
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("傳入參數：" + JsonConvert.SerializeObject(args));
            if(args.Length < 3){
                System.Console.WriteLine("請輸入 {host} {username} {password} {localPath} {remotePath}");
                return;
            }
            
            var host = args[0];
            var username = args[1];
            var password = args[2];
            var localPath = (args.Length > 3 ) ? args[3] : null;
            var remotePath = (args.Length > 4 ) ? args[4] : null;
            Console.WriteLine($" host:{host} \n username:{username} \n password:{password} \n localPath:{localPath}\n remotePath:{remotePath}");

            Upload(host, username, password, localPath, remotePath);
        }

        public static void Upload(string host, string username, string password, string localPath=null, string remotePath = null)
        {  

            var connectionInfo = new ConnectionInfo(host, username, new PasswordAuthenticationMethod(username, password));
            
          
            var client = new SftpClient(connectionInfo);
            
            client.KeepAliveInterval = TimeSpan.FromSeconds(60);
            client.ConnectionInfo.Timeout = TimeSpan.FromMinutes(180);
            client.OperationTimeout = TimeSpan.FromMinutes(180);
            
            client.Connect();
            
            bool connected = client.IsConnected;
            System.Console.WriteLine("connect ok");

            if(localPath != null && remotePath!= null){
                using (var uplfileStream = System.IO.File.OpenRead(localPath)){
                    client.UploadFile(uplfileStream, remotePath, true);
                }
            }
                
                
            client.Disconnect();
        }
    }
}

using Renci.SshNet;
namespace SftpConn
{
    public class SendFileToServer
    {
       
        public static int Upload(string host, string username, string password, string fileName)
        {  

            var connectionInfo = new ConnectionInfo(host, "sftp", new PasswordAuthenticationMethod(username, password));
            // Upload File
            using (var sftp = new SftpClient(connectionInfo)){
                sftp.Connect();
                System.Console.WriteLine("connect ok");
                //sftp.ChangeDirectory("/MyFolder");
                //using (var uplfileStream = System.IO.File.OpenRead(fileName)){
                //    sftp.UploadFile(uplfileStream, fileName, true);
                //}
                sftp.Disconnect();
            }
            return 0;
        }
    }
}
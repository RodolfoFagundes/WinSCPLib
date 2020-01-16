using System;
using System.Runtime.InteropServices;
using WinSCP;
using RGiesecke.DllExport;

namespace WinSCPLib
{
    [Guid("407E8429-3A21-4FB7-B003-837343123C6C")]
    [ComVisible(true)]
    public class Main
    {
        [DllExport]
        public static int Upload(
            string hostName,
            string userName,
            string password,
            int portNumber,
            string sshHostKeyFingerprint,
            string originFile,
            string destinationPath
        )
        {
            try
            {
                LogGenerator.Config();

                // Setup session options
                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = hostName,
                    UserName = userName,
                    Password = password,
                    PortNumber = portNumber,
                    SshHostKeyFingerprint = sshHostKeyFingerprint
                };

                LogGenerator.Add("Iniciando upload do arquivo " + originFile + " via gerenciador", Enumerators.LogLevels.Info);
                TransferOperationResult transferResult = FileManager.Upload(
                    sessionOptions,
                    originFile,
                    destinationPath
                );
                LogGenerator.Add("Upload via gerenciador realizado com sucesso", Enumerators.LogLevels.Info);

                LogGenerator.Add("Iniciando verificação dos arquivos transmitidos", Enumerators.LogLevels.Info);
                foreach (TransferEventArgs transfer in transferResult.Transfers)
                {
                    Console.WriteLine();
                    LogGenerator.Add("Upload do arquivo " + transfer.FileName + " realizado com sucesso", Enumerators.LogLevels.Info);
                }
                LogGenerator.Add("Finalizando verificação dos arquivos transmitidos", Enumerators.LogLevels.Info);

                return 1;
            }
            catch (Exception e)
            {
                LogGenerator.Add("Erro: " + e.Message, Enumerators.LogLevels.Error);
                return 0;
            }
        }
    }
}

using System;
using WinSCP;

namespace WinSCPLib
{
    public class FileManager
    {
        public static TransferOperationResult Upload(SessionOptions sessionOptions, string originFile, string destinationPath)
        {
            try
            {
                using (Session session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);

                    // Upload files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;

                    TransferOperationResult transferResult = session.PutFiles(@originFile, @destinationPath, false, transferOptions);                    

                    // Throw on any error
                    transferResult.Check();

                    return transferResult;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

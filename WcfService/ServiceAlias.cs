using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using NLog;
using SqliteDB;

namespace WcfService
{
    /// <summary>
    /// This is an implementation of interface IServiceAlias methods
    /// </summary>
    public class ServiceAlias : IServiceAlias
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly string pathDataBase = ConfigurationManager.AppSettings["pathDataBaseAlias"]; // Get DB file with aliases
        private List<string> ipItems;

        /// <summary>
        /// Get string alias list separated by " "
        /// </summary>
        /// <returns></returns>
        public List<string> GetDataAlias()
        {
            try
            {
                LogWriter("public string GetDataAlias ");
                OperationContext context = OperationContext.Current;
                CheckIp(context);
                var dataBase = new SqliteDatabase(pathDataBase);
                return (List<string>) dataBase.AliasList();
            }

            catch (BlackListExeption ex)
            {
                var fault = new InvalidUserIPFault(ex.Message);
                throw new FaultException<InvalidUserIPFault>(fault, new FaultReason(fault.ToString()));
            }
            catch (InvalidOperationException ex)
            {
                var fault = new ItemNotExcistFault(ex.Message);
                throw new FaultException<ItemNotExcistFault>(fault, new FaultReason(fault.ToString()));
            }
            catch (Exception ex)
            {
                var fault = new InvalidUnknownFault(ex.Message);
                throw new FaultException<InvalidUnknownFault>(fault, new FaultReason(fault.ToString()));
            }
        }

        /// <summary>
        /// Get node from selected dir
        /// </summary>
        /// <param name="aliasNode"></param>
        /// <param name="aliasName"></param>
        /// <returns></returns>
        public CompositeTypeNode GetNode(string aliasNode, string aliasName)
        {
            try
            {
                OperationContext context = OperationContext.Current;
                CheckIp(context);
                var dataBase = new SqliteDatabase(pathDataBase);
                string endDirectory = Path.Combine(dataBase.GetAliasPath(aliasName), aliasNode);
                if (!Directory.Exists(endDirectory)) throw new ItemNotFounfExeption(" Directory meanwhile had been disappearing... ");
                string[] nodeDir = Directory.GetDirectories(endDirectory);
                string[] nodeFiles = Directory.GetFiles(endDirectory);
                var nodeArray = new AliasNode[nodeDir.Length + nodeFiles.Length];
                for (int i = 0; i < nodeArray.Length; i++)
                    nodeArray[i] = new AliasNode();

                for (int i = 0; i < nodeDir.Length; i++)
                {
                    nodeArray[i].IsDirectory = true;
                    var info = new DirectoryInfo(nodeDir[i]);
                    nodeArray[i].ItemName = info.Name;
                }

                for (int i = 0; i < nodeFiles.Length; i++)
                {
                    nodeArray[i + nodeDir.Length].IsDirectory = false;
                    nodeArray[i + nodeDir.Length].ItemName = Path.GetFileName(nodeFiles[i]);
                }

                var node = new CompositeTypeNode
                    {
                        NodeArray = nodeArray
                    };
                LogWriter("Node element created for " + aliasNode);
                return node;
            }

            catch (BlackListExeption ex)
            {
                var fault = new InvalidUserIPFault(ex.Message);
                throw new FaultException<InvalidUserIPFault>(fault, new FaultReason(fault.ToString()));
            }
            catch (AliasNotExistExeption ex)
            {
                var fault = new AliasNotExistFault(ex.Message);
                throw new FaultException<AliasNotExistFault>(fault, new FaultReason(fault.ToString()));
            }
            catch (InvalidOperationException ex)
            {
                var fault = new ItemNotExcistFault(ex.Message);
                throw new FaultException<ItemNotExcistFault>(fault, new FaultReason(fault.ToString()));
            }
            catch (ItemNotFounfExeption ex)
            {
                var fault = new ItemNotExcistFault(ex.Message);
                throw new FaultException<ItemNotExcistFault>(fault, new FaultReason(fault.ToString()));
            }
            catch (DirectoryNotFoundException ex)
            {
                var fault = new ItemNotExcistFault(ex.Message);
                throw new FaultException<ItemNotExcistFault>(fault, new FaultReason(fault.ToString()));
            }
            catch (SQLiteException ex)
            {
                var fault = new InvalidDataBaseFault("Database error. " + ex.Message);

                throw new FaultException<InvalidDataBaseFault>(fault, new FaultReason(fault.ToString()));
            }
            catch (Exception ex)
            {
                var fault = new InvalidUnknownFault(ex.Message);
                throw new FaultException<InvalidUnknownFault>(fault, new FaultReason(fault.ToString()));
            }
        }

        /// <summary>
        /// get for file downloading
        /// </summary>
        /// <param name="fullFileName"></param>
        /// <param name="aliasName"></param>
        /// <returns></returns>
        public Stream GetFile(string fullFileName, string aliasName)
        {
            try
            {
                OperationContext context = OperationContext.Current;
                CheckIp(context);
                var dataBase = new SqliteDatabase(pathDataBase);
                string pathFile = Path.Combine(dataBase.GetAliasPath(aliasName), fullFileName);
                var stream = new MemoryStream();
                using (FileStream file = File.OpenRead(pathFile))
                {
                    file.CopyTo(stream);
                }
                stream.Position = 0L;
                return stream;
            }
            catch (BlackListExeption ex)
            {
                var fault = new InvalidUserIPFault(ex.Message);
                throw new FaultException<InvalidUserIPFault>(fault, new FaultReason(fault.ToString()));
            }
            catch (AliasNotExistExeption ex)
            {
                var fault = new AliasNotExistFault(ex.Message);
                throw new FaultException<AliasNotExistFault>(fault, new FaultReason(fault.ToString()));
            }
            catch (FileNotFoundException ex)
            {
                var fault = new ItemNotExcistFault(ex.Message);
                throw new FaultException<ItemNotExcistFault>(fault, new FaultReason(fault.ToString()));
            }

            catch (Exception ex)
            {
                var fault = new InvalidUnknownFault(ex.Message);
                throw new FaultException<InvalidUnknownFault>(fault, new FaultReason(fault.ToString()));
            }
        }

        /// <summary>
        /// get file lenth
        /// </summary>
        /// <param name="fullFileName"></param>
        /// <param name="aliasName"></param>
        /// <returns></returns>
        public int LenghtFile(string fullFileName, string aliasName)
        {
            try
            {
                OperationContext context = OperationContext.Current;
                CheckIp(context);
                var dataBase = new SqliteDatabase(pathDataBase);
                string pathFile = Path.Combine(dataBase.GetAliasPath(aliasName), fullFileName);
                FileStream file = File.Open(pathFile, FileMode.Open);
                var lenght = (int) file.Length;
                file.Close();

                return lenght;
            }
            catch (BlackListExeption ex)
            {
                var fault = new InvalidUserIPFault(ex.Message);
                throw new FaultException<InvalidUserIPFault>(fault, new FaultReason(fault.ToString()));
            }
            catch (AliasNotExistExeption ex)
            {
                var fault = new AliasNotExistFault(ex.Message);
                throw new FaultException<AliasNotExistFault>(fault, new FaultReason(fault.ToString()));
            }
            catch (FileNotFoundException ex)
            {
                var fault = new ItemNotExcistFault(ex.Message);
                throw new FaultException<ItemNotExcistFault>(fault, new FaultReason(fault.ToString()));
            }

            catch (Exception ex)
            {
                var fault = new InvalidUnknownFault(ex.Message);
                throw new FaultException<InvalidUnknownFault>(fault, new FaultReason(fault.ToString()));
            }
        }

        /// <summary>
        /// get MD5 hash from file
        /// </summary>
        /// <param name="fullFileName"></param>
        /// <param name="aliasName"></param>
        /// <returns></returns>
        public string MD5HashFile(string fullFileName, string aliasName)
        {
            try
            {
                OperationContext context = OperationContext.Current;
                CheckIp(context);
                byte[] retVal;
                var bd = new SqliteDatabase(pathDataBase);
                string pathfile = Path.Combine(bd.GetAliasPath(aliasName), fullFileName);
                using (var file = new FileStream(pathfile, FileMode.Open))
                using (MD5 md5 = new MD5CryptoServiceProvider())
                    retVal = md5.ComputeHash(file);


                var sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }

            catch (BlackListExeption ex)
            {
                var fault = new InvalidUserIPFault(ex.Message);
                throw new FaultException<InvalidUserIPFault>(fault, new FaultReason(fault.ToString()));
            }
            catch (AliasNotExistExeption ex)
            {
                var fault = new AliasNotExistFault(ex.Message);
                throw new FaultException<AliasNotExistFault>(fault, new FaultReason(fault.ToString()));
            }
            catch (FileNotFoundException ex)
            {
                var fault = new ItemNotExcistFault(ex.Message);
                throw new FaultException<ItemNotExcistFault>(fault, new FaultReason(fault.ToString()));
            }

            catch (Exception ex)
            {
                var fault = new InvalidUnknownFault(ex.Message);
                throw new FaultException<InvalidUnknownFault>(fault, new FaultReason(fault.ToString()));
            }
        }

        private void CheckIp(OperationContext context)
        {
            try
            {
                MessageProperties properties = context.IncomingMessageProperties;
                LogWriter("private void CheckIp " + context);
                ipItems = new List<string>();
                var dataBase = new SqliteDatabase(pathDataBase);
                ipItems = (List<string>) dataBase.LoadIp();
                var endPoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                if (endPoint != null)
                {
                    string propertyText = endPoint.Address;
                    LogWriter("Endpoint IP  " + propertyText + " Checking with black list");
                    foreach (string ip in ipItems)
                    {
                        if (propertyText.Contains(ip))
                        {
                            throw new BlackListExeption("Endpoint IP = " + ip + "  is in black list!  Connection  closed");
                        }
                    }
                }
            }
            catch (BlackListExeption ex)
            {
                throw new BlackListExeption(ex.Message);
            }
            catch (SQLiteException ex)
            {
                throw new FaultException<InvalidDataBaseFault>(new InvalidDataBaseFault("Database error. " + ex.Message));
            }
        }


        private void LogWriter(string text)
        {
            Logger.Info(text);
        }
    }
}
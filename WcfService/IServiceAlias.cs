using System.Collections.Generic;
using System.IO;
using System.ServiceModel;

namespace WcfService
{
    /// <summary>
    /// The interface IServiceAlias descripts  the methods our service performs
    /// </summary>
    [ServiceContract]
    public interface IServiceAlias
    {
        /// <summary>
        /// This method gives a list of available aliases
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof (InvalidUserIPFault))]
        [FaultContract(typeof (InvalidDataBaseFault))]
        [FaultContract(typeof (AliasNotExistFault))]
        List<string> GetDataAlias();

        /// <summary>
        /// Get node from selected dir
        /// </summary>
        /// <param name="aliasNode"></param>
        /// <param name="aliasName"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof (InvalidUserIPFault))]
        [FaultContract(typeof (InvalidDataBaseFault))]
        [FaultContract(typeof (ItemNotExcistFault))]
        [FaultContract(typeof (AliasNotExistFault))]
        CompositeTypeNode GetNode(string aliasNode, string aliasName);

        /// <summary>
        /// Download file from node tree
        /// </summary>
        /// <param name="fullFileName"></param>
        /// <param name="aliasName"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof (InvalidUserIPFault))]
        [FaultContract(typeof (ItemNotExcistFault))]
        [FaultContract(typeof (AliasNotExistFault))]
        Stream GetFile(string fullFileName, string aliasName);

        /// <summary>
        /// Get file lenth. It's used for downloading
        /// </summary>
        /// <param name="fullFileName"></param>
        /// <param name="aliasName"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof (InvalidUserIPFault))]
        [FaultContract(typeof (ItemNotExcistFault))]
        [FaultContract(typeof (AliasNotExistFault))]
        int LenghtFile(string fullFileName, string aliasName);

        /// <summary>
        /// Get hash string MD5 from file for checking downloading
        /// </summary>
        /// <param name="fullFileName"></param>
        /// <param name="aliasName"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof (InvalidUserIPFault))]
        [FaultContract(typeof (AliasNotExistFault))]
        [FaultContract(typeof (ItemNotExcistFault))]
        string MD5HashFile(string fullFileName, string aliasName);
    }
}
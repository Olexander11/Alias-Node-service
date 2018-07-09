using System;
using System.Runtime.Serialization;

namespace WcfService
{
    [DataContract]
    internal class InvalidUserIPFault
    {
        public InvalidUserIPFault(string message)
        {
            Message = message;
        }

        [DataMember]
        private string Message { get; set; }
    }

    [DataContract]
    internal class InvalidDataBaseFault
    {
        public InvalidDataBaseFault(string message)
        {
            Message = message;
        }

        [DataMember]
        private string Message { get; set; }
    }

    [DataContract]
    internal class InvalidUnknownFault
    {
        public InvalidUnknownFault(string message)
        {
            Message = message;
        }

        [DataMember]
        private string Message { get; set; }
    }


    public class ItemNotFounfExeption : Exception
    {
        public ItemNotFounfExeption()
        {
        }

        public ItemNotFounfExeption(String message)
            : base(message)
        {
        }
    }

    public class BlackListExeption : Exception
    {
        public BlackListExeption()
        {
        }

        public BlackListExeption(String message)
            : base(message)
        {
        }
    }


    [DataContract]
    internal class ItemNotExcistFault
    {
        public ItemNotExcistFault(string message)
        {
            Message = message;
        }

        [DataMember]
        private string Message { get; set; }
    }

    [DataContract]
    internal class AliasNotExistFault
    {
        public AliasNotExistFault(string message)
        {
            Message = message;
        }

        [DataMember]
        private string Message { get; set; }
    }
}
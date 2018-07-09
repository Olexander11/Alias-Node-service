using System.Runtime.Serialization;

namespace WcfService
{
    [DataContract]
    public class AliasNode
    {
        [DataMember]
        public string ItemName { get; set; }

        [DataMember]
        public bool IsDirectory { get; set; }
    }
}
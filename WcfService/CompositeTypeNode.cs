using System.Runtime.Serialization;

namespace WcfService
{
    [DataContract]
    public class CompositeTypeNode
    {
        [DataMember]
        public AliasNode[] NodeArray { get; set; }
    }
}
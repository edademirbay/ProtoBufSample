using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoBufSample.Dto
{
    [ProtoContract]
    [ProtoInclude(10,typeof(Order))]   
    public class BaseClass
    {
        [ProtoMember(1)]
        public DateTime CreatedDate { get; set; }

        [ProtoMember(2)]
        public string CreatedBy { get; set; }

        [ProtoMember(3)]
        public DateTime ModifiedDate { get; set; }

        [ProtoMember(4)]
        public string ModifiedBy { get; set; }
    }
}

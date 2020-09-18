using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoBufSample.Dto
{
    [ProtoContract]
    public class Order : BaseClass
    {
        [ProtoMember(1)]
        public int ID { get; set; }
        [ProtoMember(2)]
        public string Number { get; set; }

        [ProtoMember(3)]
        public DateTime Date { get; set; }

        [ProtoMember(4)]
        public decimal TotalPrice { get; set; }

        [ProtoMember(5)]
        public List<Product> Products { get; set; }
    }
}

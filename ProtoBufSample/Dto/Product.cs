using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoBufSample.Dto
{
   [ProtoContract]
  
   public class Product
    {
        [ProtoMember(1)]
        public int ID { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public decimal Price { get; set; }

        [ProtoMember(4)]
        public int Quantity { get; set; }

       
    }
}

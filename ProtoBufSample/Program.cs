using Newtonsoft.Json;
using ProtoBufSample.Dto;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProtoBufSample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Fake Data


            List<Order> orderList = new List<Order>();
            orderList.Add(new Order
            {

                CreatedBy = "demirbay",
                CreatedDate = DateTime.Now,
                Number = "ED123456789",
                Date = new DateTime(2020, 9, 10),
                TotalPrice = 222.15m,
                Products = new List<Product>() { new Product(){ ID =1 ,Name="Ton Balığı", Price=30.0m , Quantity=1}

            }
            });

            orderList.Add(new Order() { Number = "OB8956233", Date = DateTime.Now, TotalPrice = 600.0m });
            byte[] byteOrderList = null;
            List<Order> listOrder = null;
           
         
            try
            {
                var watchProtoBuf = System.Diagnostics.Stopwatch.StartNew();
                for (var i = 0; i < 3000000; i++)
                {
                    using (var stream = new MemoryStream())
                    {
                        ProtoBuf.Serializer.Serialize(stream, orderList);
                        byteOrderList = stream.ToArray();
                    }
                    using (var stream = new MemoryStream(byteOrderList))
                    {
                        listOrder = ProtoBuf.Serializer.Deserialize<List<Order>>(stream);
                       
                    }
                }
                watchProtoBuf.Stop();
                var elapsedMsProtoBuf = watchProtoBuf.ElapsedMilliseconds;
                Console.WriteLine($"ProtoBuf-net ile 3.000.000 datanın Serialize/Deserialize süresi(ms): {elapsedMsProtoBuf}");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
               
                var watchJson = System.Diagnostics.Stopwatch.StartNew();
                for (int i = 0; i < 3000000; i++)
                {
                    var serializedDataList = JsonConvert.SerializeObject(orderList);
                    listOrder = JsonConvert.DeserializeObject<List<Order>>(serializedDataList);
                }
                watchJson.Stop();
                var elapsedMsJson = watchJson.ElapsedMilliseconds;
                Console.WriteLine($"Newtonsoft.Json ile 3.000.000  datanın Serialize/Deserialize süresi(ms): {elapsedMsJson}");
            }

            catch(Exception ex)
            {
                throw ex;
            }
           

            #endregion
        }
    }
}

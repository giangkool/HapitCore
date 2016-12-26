using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HapitCore
{
    class IDPW
    {
            public ObjectId _id { get; set; }
            public string ID { get; set; }
            public string PW { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HapitCore
{
    class ObjectDB
    {
        public Object _id { get; set; }
        public string ID { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace HapitCore
{
    public class MongoHelper
    {
        private MongoDatabase database;
        public MongoHelper()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");

            MongoServer _server = client.GetServer();
            this.database = _server.GetDatabase("user");

            MongoCollection collection = database.GetCollection<IDPW>("IDPW");
        }
        public MongoCollection collection
        {
            get
            {
                return database.GetCollection<IDPW>("IDPW");
            }
        }
        public void swdata(string ID,string PW)
        {
            IDPW sv = new IDPW();
            sv.ID = ID;
            sv.PW = PW;
            collection.Save(sv).ToBsonDocument("");
        }
        public void updata(string ID,string IDupdate,string PW,string PWupdate)
        {
            IMongoQuery query = Query.EQ("ID",ID);
            if (query != null)
            {
                IMongoQuery query1 = Query.EQ("PW", PW);
                IMongoUpdate update = Update<IDPW>
                                                 .Set(x => x.ID, IDupdate)
                                                 .Set(x => x.PW, PWupdate);
                collection.Update(query1, update);
            }
            
            
        }
        public void rmdata(string ID,string PW)
        {
            IMongoQuery query = Query.EQ("ID", ID);
            if (query!=null) {
                IMongoQuery query1 = Query.EQ("PW", PW);
                collection.Remove(query1);
            }
                
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace HapitCore
{
    public class MongoDB
    {
        private MongoDatabase database;
        public MongoDB()
        {
            MongoClient _client = new MongoClient("mongodb://localhost:27017");
            MongoServer _server = _client.GetServer();
            this.database = _server.GetDatabase("user");
<<<<<<< HEAD
            MongoCollection _colection = database.GetCollection<ObjectDB>("Infor");
=======

            MongoCollection collection = database.GetCollection("IDPW");
>>>>>>> origin/master
        }
        public MongoCollection collection
        {
            get
            {
<<<<<<< HEAD
                return database.GetCollection<ObjectDB>("Infor");
            }
        }
        public bool checknull(string id)//kiểm tra id đó đã có người sử dụng chưa
        {
            IMongoQuery query = Query.EQ("ID", id);
            return (query == null) ? true : false;
        }

        public void Insert(string ID, string PW, string Name, int Number)
        {
            ObjectDB sv = new ObjectDB();
            sv.ID = ID;
            sv.Password = PW;
            sv.Number = Number;
            sv.Name = Name;
            if (checknull(ID) == true)//trường hợp rỗng thì thêm vào colection
            {
                collection.Save(sv).ToBsonDocument();

            }

=======
                return database.GetCollection("IDPW");
            }
        }
        ///t sử dụng mảng để insert vào 
        public void swdata(string[] info,List<string> usr)
        {
            BsonDocument user = new BsonDocument();
            int i = 0;
            foreach (string str in usr) {
                i++;
                user.Add(info[i], str);
            }            
            collection.Insert(user);
            
>>>>>>> origin/master
        }
        public void update(string kid, string ID, string PW, string Name, int Number)
        {
            if (checknull(kid) == false)
            {
                IMongoQuery query = Query.EQ("ID", kid);
                IMongoUpdate update = Update<ObjectDB>
                                                 .Set(x => x.ID, ID)
                                                 .Set(x => x.Password, PW)
                                                 .Set(x => x.Name, Name)
                                                 .Set(x => x.Number, Number);
                collection.Update(query, update);
            }
        }
        public void delete(string ID)
        {
            if (checknull(ID) == false)
            {
                IMongoQuery query = Query.EQ("ID", ID);
                collection.Remove(query);
            }
        }
    }
}

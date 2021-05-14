using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.DataAccess.MongoDB
{
    public class HomeWorkFiles
    {
        public ObjectId Id { get; set; }
        public byte[] Content { get; set; }
    }
}

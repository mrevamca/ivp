using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connecttocosmosdb.Support
{
    public class leg
    {
        public leg(string id, string bookingNo, string containerNo, string vendor, string direction)
        {
            this.id = id;
            this.bookingNo = bookingNo;
            this.containerNo = containerNo;
            this.vendor = vendor;
            this.direction = direction;
        }

        public string PartitionKey => id;
            public string id { get; set; }
            public string bookingNo { get; set; }
            public string containerNo { get; set; }
            public string vendor { get; set; }
            public string direction { get; set; }
            public string _rid { get; set; }
            public string _self { get; set; }
            public string _etag { get; set; }
            public string _attachments { get; set; }
            public int _ts { get; set; }
        

    }
}

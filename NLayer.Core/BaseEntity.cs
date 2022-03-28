using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    public abstract class BaseEntity
    {
        //abstract yapmamızın sebebi nesne örneği alınmasın
        //abstractlar ve interfaceler new anahtar sözcüğüyle tanımlanamaz.



        public int id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}

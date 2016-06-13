using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Picture
    {
        public int Id { get; set; }
        public string SeoFilename { get; set; }
        public string MimeType { get; set; }
        public virtual ICollection<ProductPicture> ProductPictures { get; set; }
    }
}

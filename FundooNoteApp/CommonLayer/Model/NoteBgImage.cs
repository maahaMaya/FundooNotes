using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace CommonLayer.Model
{
    public class NoteBgImage
    {
        public long NoteID { get; set; }
        public IFormFile ImgFile { get; set; }
    }
}

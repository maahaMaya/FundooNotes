using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class NewNote
    {
        public string Title { get; set; }
        public string Note { get; set; }
        public string Color { get; set; }
        public bool IsArchive { get; set; }
        public bool IsPin { get; set; }
    }
}

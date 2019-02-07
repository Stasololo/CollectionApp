using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollectionApp.ViewModel
{
    public class ClisubfmlVM
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string SelectedClientNameStr { get; set; }
        public List<long> SelectedClientIds { get; set; }
    }
}
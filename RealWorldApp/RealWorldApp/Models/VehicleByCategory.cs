using System;
using System.Collections.Generic;
using System.Text;

namespace RealWorldApp.Models
{
    public class VehicleByCategory
    {
        public int id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public string model { get; set; }
        public string location { get; set; }
        public string company { get; set; }
        public DateTime datePosted { get; set; }
        public bool isFeatured { get; set; }
        public bool imageUrl { get; set; }
        //ako je false onda text free
        public string IsFeaturedAd => isFeatured ? "Featured" : "Free";
        //format datuma
        public string AdPostedDate => datePosted.ToString("y");
        public string FullImageUrl => $"http://cvehicles.azurewebsites.net/{imageUrl}";
    }
}

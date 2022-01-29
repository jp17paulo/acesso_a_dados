using System;

namespace BaltaDataAccess.Models{
    public class Category{
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public string Summary { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        public bool Feature { get; set; }
    }
}
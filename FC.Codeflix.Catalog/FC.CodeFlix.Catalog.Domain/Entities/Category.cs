using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.CodeFlix.Catalog.Domain.Entities
{
    public class Category
    {

        public Guid Id { get; private set; }
        public String Name { get; private set; }
        public String Description { get; private set; }
        public  DateTime CreatedAt { get; private set; }
        public bool IsActive { get; private set; }


    
        public Category(string name, string description, bool isActive = true)
        {
            this.Id = Guid.NewGuid();
            Name = name;
            Description = description;
            this.IsActive = isActive;
            this.CreatedAt = DateTime.Now;
        }
    }
}

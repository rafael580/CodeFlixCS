using FC.CodeFlix.Catalog.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

            Validate();
        }


        public void Validate()
        {
            if (String.IsNullOrWhiteSpace(this.Name))
            {

                throw new EntityValidationException($"{nameof(Name)} should not be empty or null");

            }
            if (Description == null)
            {
                throw new EntityValidationException($"{nameof(Description)} should not be null");
            }

        }

        
    }
}

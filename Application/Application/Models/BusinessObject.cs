using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Application.Models
{
    public class BusinessObject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

    }

    public class BusinessObjectRepository
    {
        private readonly List<BusinessObject> _businessObjects;
        public BusinessObjectRepository()
        {
            _businessObjects = new List<BusinessObject>();
        }

        public BusinessObject GetById(int id)
        {
            return _businessObjects.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(BusinessObject businessObject)
        {
            // Use in memory list to insert the businessObject
            _businessObjects.Add(businessObject);
        }

        public void Update(BusinessObject businessObject)
        {
            // Use in memory list to update the businessObject
            var existingBusinessObject = _businessObjects.FirstOrDefault(b => b.Id == businessObject.Id);
            if (existingBusinessObject != null)
            {
                existingBusinessObject.Name = businessObject.Name;
                existingBusinessObject.Description = businessObject.Description;
            }
        }

        public void Delete(int id)
        {
            // Use in memory list to delete the businessObject
            var existingBusinessObject = _businessObjects.FirstOrDefault(b => b.Id == id);
            if (existingBusinessObject != null)
            {
                _businessObjects.Remove(existingBusinessObject);
            }
        }

        public IEnumerable<BusinessObject> GetAll()
        {
            // Use in memory list to retrieve all businessObjects and return them as a list
            return _businessObjects;
        }
    }

}
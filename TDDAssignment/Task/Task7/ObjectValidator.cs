using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDAssignment.Task.Task7
{
    public class ObjectValidator
    {
        public bool IsNull(object obj)
        {
            if (obj == null)
            {
                return true;
            }
            return false;
        }
        public List<string> GetNullProperties(object obj)
        {
            List<string> nullProperties = new List<string>();
            if (obj == null)
            {
                return nullProperties;
            }
            if (obj.GetType().IsValueType)
            {
                throw new ArgumentException("Object is a value type");
            }
            var properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.GetValue(obj) == null)
                {
                    nullProperties.Add(property.Name);
                }
            }
            return nullProperties;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatFramework.ViewModels
{
    public class DatDelegate
    {
        public string PropertyName { get; private set; }

        public Delegate Delegate { get; private set; }   

        public DatDelegate(string propertyName, object target, Action<object> action)
        {
            this.PropertyName = propertyName;
            this.Delegate = action;
        }

        public DatDelegate(DatList<object> list, object target, Action<object> action)
        {
            
        }        
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace DatFramework.ViewModels
{
    public delegate void SelectedItemChanged();
    
    [Serializable]
    public class DatList<T> : ObservableCollection<T>
    {
        private T selectedItem;

        public new IList<T> Items
        {
            get
            {
                return base.Items;
            }
        }
        
        public T SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                Set(ref selectedItem, value);
            }
        }

        public SelectedItemChanged SelectedItemChanged;

        public DatList()
            : base()
        {
            
        }

        public DatList(List<T> list)
            : base(list)
        {

        }

        public new void Add(T item)
        {
            base.InsertItem(Count, item);
        }

        public new void Remove(T item)
        {
            base.RemoveItem(Items.IndexOf(item));
        }

        public void SetItems(List<T> list)
        {
            Clear();

            list.ForEach(i =>
            {
                base.InsertItem(Count, i);
            });

            if (!list.Any())
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        public bool Set(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }
            else
            {
                field = value;
                OnPropertyChanged(new PropertyChangedEventArgs(propertyName));

                if (propertyName.Equals("SelectedItem"))
                {
                    OnSelectedItemChanged();
                }

                return true;
            }
        }

        public void OnSelectedItemChanged()
        {
            if (SelectedItemChanged != null)
            {
                SelectedItemChanged();
            }
        }
    }
}

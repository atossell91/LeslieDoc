using System.Collections;
using System.Collections.Generic;

namespace LeslieDoc {
    public class CellCollectionGroup : IEnumerable {
        private Dictionary<string, ICell[]> cellGroups;

        public CellCollectionGroup()
        {
            cellGroups = new Dictionary<string, ICell[]>();
        }

        public ICell[] this[string key] { 
            get { return cellGroups[key]; }
            set { cellGroups[key] = value; }
        }

        public IEnumerator GetEnumerator()
        {
            return cellGroups.GetEnumerator();
        }
    }
}
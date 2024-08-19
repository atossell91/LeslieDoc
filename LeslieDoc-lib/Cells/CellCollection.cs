using System.Collections;
using System.Collections.Generic;

namespace LeslieDoc {
    public class CellCollection : IEnumerable {
        Dictionary<string, ICell> cells;

        public CellCollection()
        {
            cells = new Dictionary<string, ICell>();
        }

        public ICell this[string key] { 
            get { return cells[key]; }
            set { cells[key] = value; }
        }

        public IEnumerator GetEnumerator()
        {
            return cells.GetEnumerator();
        }
    }
}
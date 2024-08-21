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

        public void Add(string key, ICell cell) {
            cells.Add(key, cell);
        }

        public IEnumerator GetEnumerator()
        {
            return cells.GetEnumerator();
        }

        public void ConcatCollection(CellCollection otherCollection) {
            foreach (var cell in otherCollection.cells) {
                cells.Add(cell.Key, cell.Value);
            }
        }
    }
}
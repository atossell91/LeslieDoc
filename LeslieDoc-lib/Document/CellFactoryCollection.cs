using System.Collections;
using System.Collections.Generic;

namespace LeslieDoc {
    public class CellFactoryCollection : IEnumerable {
        private Dictionary<string, ICellFactory> factories;

        public CellFactoryCollection()
        {
            factories = new Dictionary<string, ICellFactory>();
        }

        public CellFactoryCollection(Dictionary<string, ICellFactory> factories) {
            this.factories = factories;
        }

        public ICellFactory this[string name] {
            get {
                return factories[name];
            }
            set {
                factories[name] = value;
            }
        }

        public void Add(string name, ICellFactory factory) {
            factories.Add(name, factory);
        }

        public ICellFactory GetCellFactory(string name)
        {
            return factories[name];
        }

        public IEnumerator GetEnumerator()
        {
            return factories.GetEnumerator();
        }
    }
}
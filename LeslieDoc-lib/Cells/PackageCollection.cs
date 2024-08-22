using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace LeslieDoc {
    public class PackageCollection : IEnumerable {
        private Dictionary<string, Section> _sections;

        public Section this[string key] { 
            get { return _sections[key]; }
            set { _sections[key] = value; }
        }

        public void Add(string key, Section section) {
            _sections.Add(key, section);
        }

        public void Concat(PackageCollection packageCollection) {
            foreach (var section in packageCollection._sections) {
                _sections.Add(section.Key, section.Value);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return _sections.GetEnumerator();
        }
    }
}
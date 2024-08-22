using System.Collections;
using System.Collections.Generic;

namespace LeslieDoc {
    public class Section {
        public CellCollection Cells { get; set; }
        public CellCollectionGroup CellGroups { get; set; }
        public Dictionary<string, Section> Sections { get; set; }
    }
}
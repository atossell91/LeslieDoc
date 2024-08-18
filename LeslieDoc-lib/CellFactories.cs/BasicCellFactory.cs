using System.Text.Json;

namespace LeslieDoc {
    public class BasicCellFactory : ICellFactory
    {
        public ICell CreateCell(JsonElement elem)
        {
            throw new System.NotImplementedException();
        }
    }
}
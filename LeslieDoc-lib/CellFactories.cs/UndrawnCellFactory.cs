using System.Text.Json;

namespace LeslieDoc {
    public class UndrawnCellFactory : ICellFactory
    {
        public ICell CreateCell(JsonElement elem)
        {
            throw new System.NotImplementedException();
        }
    }
}
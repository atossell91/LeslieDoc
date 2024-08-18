using System.Text.Json;

namespace LeslieDoc {
    public interface ICellFactory {
        ICell CreateCell(JsonElement elem);
    }
}
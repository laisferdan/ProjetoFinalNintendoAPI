using Microsoft.AspNetCore.Mvc;

namespace ProjetoFinalNintendoAPI.Interfaces
{
    public interface INintendoController<T, K, D>
    {
        Task<IActionResult> GetAllRecordsWithPagination(int page, int limit);
        Task<IActionResult> GetSingleRecord(int id);
        Task<IActionResult> Post(K entity);
        Task<IActionResult> Put(int id, K entity);
        Task<IActionResult> Patch(int id, D entity);
        Task<IActionResult> Delete(int id);

    }
}
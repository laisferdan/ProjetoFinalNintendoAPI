using Microsoft.AspNetCore.Mvc;

namespace ProjetoFinalNintendoAPI.Interfaces
{
    public interface INintendoController<T, K, D>
    {
        Task<IActionResult> GetAllRecordsWithPagination(int page, int pageLimit);
        Task<IActionResult> GetRecordById(int id);
        Task<IActionResult> SearchAndFilterRecordsWithPagination(T entity, int page, int pageLimit);
        Task<IActionResult> CreateNewRecord(K entity);
        Task<IActionResult> UpdateExistingRecord(int id, K entity);
        Task<IActionResult> UpdatePlatformOfExistingRecord(int id, D entity);
        Task<IActionResult> DeleteRecord(int id);

    }
}
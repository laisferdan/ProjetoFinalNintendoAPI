using Microsoft.AspNetCore.Mvc.Filters;
using ProjetoFinalNintendoAPI.Interfaces;
using ProjetoFinalNintendoAPI.Logs;
using ProjetoFinalNintendoAPI.Models;

namespace ProjetoFinalNintendoAPI.Filters
{
    public class CustomLogsFilter : IResultFilter, IActionFilter
    {
        private readonly List<int> _sucessStatusCodes;
        private readonly IRepository<NintendoGamesModel> _repository;
        private static readonly Dictionary<int, NintendoGamesModel> _contextDict = new Dictionary<int, NintendoGamesModel>();

        public CustomLogsFilter(IRepository<NintendoGamesModel> repository)
        {
            _repository = repository;
            _sucessStatusCodes = new List<int>() { StatusCodes.Status200OK, StatusCodes.Status201Created };
        }


        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Path.Value.StartsWith("/NintendoGames", StringComparison.InvariantCulture))
            {
                int id = 0;
                if (context.ActionArguments.ContainsKey("id") && int.TryParse(context.ActionArguments["id"].ToString(), out id))
                {
                    if (context.HttpContext.Request.Method.Equals("put", StringComparison.InvariantCultureIgnoreCase)
                        || context.HttpContext.Request.Method.Equals("patch", StringComparison.InvariantCultureIgnoreCase)
                        || context.HttpContext.Request.Method.Equals("delete", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var game = _repository.GetAsyncById(id).Result;
                        if (game != null)
                        {
                            var gameClone = game.clone();
                            _contextDict.Add(id, gameClone);
                        }
                    }
                }
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            if (context.HttpContext.Request.Path.Value.StartsWith("/NintendoGames", StringComparison.InvariantCulture))
            {
                if (_sucessStatusCodes.Contains(context.HttpContext.Response.StatusCode))
                {
                    var idToParse = context.HttpContext.Request.Path.ToString().Split("/").Last();
                    if (context.HttpContext.Request.Method.Equals("put", StringComparison.InvariantCultureIgnoreCase)
                        || context.HttpContext.Request.Method.Equals("patch", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var id = int.Parse(idToParse);
                        var afterUpdate = _repository.GetAsyncById(id).Result;
                        if (afterUpdate != null)
                        {
                            NintendoGamesModel beforeUpdate;
                            if (_contextDict.TryGetValue(id, out beforeUpdate))
                            {
                                CustomLogs.SaveLog(afterUpdate.Id, "Game", afterUpdate.Title, context.HttpContext.Request.Method, beforeUpdate, afterUpdate);
                                _contextDict.Remove(id);
                            }
                        }
                    }
                    else if (context.HttpContext.Request.Method.Equals("delete", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var id = int.Parse(idToParse);
                        NintendoGamesModel beforeUpdate;
                        if (_contextDict.TryGetValue(id, out beforeUpdate))
                        {
                            CustomLogs.SaveLog(beforeUpdate.Id, "Game", beforeUpdate.Title, context.HttpContext.Request.Method);
                            _contextDict.Remove(id);
                        }
                    }
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
        public void OnResultExecuting(ResultExecutingContext context) { }
    }
}
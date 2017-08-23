namespace DeluxeRestApp.Controllers
{
    #region Using statements
    using Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    #endregion

    public class LogsController : Controller
    {
        #region Private fields
        private ILogsRepository _logsRepository;
        #endregion

        #region Constructor
        public LogsController(ILogsRepository logsRepository)
        {
            this._logsRepository = logsRepository;
        }
        #endregion

        #region Api methods
        [HttpGet("logs")]
        public async Task<IActionResult> Index()
        {
            return Ok(await this._logsRepository.Get());
        }
        #endregion
    }
}

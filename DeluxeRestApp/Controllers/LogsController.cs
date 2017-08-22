namespace DeluxeRestApp.Controllers
{
    #region Usings
    using Interfaces;
    using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return Ok(this._logsRepository.Get());
        }
        #endregion
    }
}

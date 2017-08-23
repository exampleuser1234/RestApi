namespace DeluxeRestApp.Controllers
{
    #region Using statements
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.LogsModels;
    using Models.RestApiModels;
    using Models.GithubApiModels;

    #endregion

    [Route("[controller]")]
    public class CardsController : Controller
    {
        #region Private fields
        private readonly ICardsProvider _cardsProvider;
        private readonly IColumnsProvider _columnsProvider;
        private readonly ILogsRepository _logsRepository;
        #endregion

        #region Constructor
        public CardsController(ICardsProvider iCardsProvider, IColumnsProvider columnsProvider,ILogsRepository logsRepository)
        {
            _cardsProvider = iCardsProvider;
            _columnsProvider = columnsProvider;
            _logsRepository = logsRepository;
        }
        #endregion

        #region Api Methods
        [HttpPost("replace")]
        public async Task<IActionResult> Replace([FromBody] ReplaceModel model)
        {
            if (!model.TransleteColumnsNames(GithubServices.Environment.ColumnNamesIds))
                return StatusCode(422);

            async Task<bool> Func(Card card)
            {
                var newNote = card.note.Replace(model.pattern, model.change_to);
                Card newCard;
                if ((newCard = await _cardsProvider.Edit(card.id.ToString(), newNote))!= null)
                {
                    await _logsRepository.Insert(new Log()
                    {
                        CardColumn = model.column,
                        CardId = newCard.id.ToString(),
                        CardNote = newCard.note,
                        Operation = Operation.Edit
                    });
                    return true;
                }
                return false;
            }

            return StatusCode(await UseCardsWithPattern(model.column, model.pattern, Func));
        }
        
        [HttpPost("move")]
        public async Task<IActionResult> Move([FromBody] MoveModel model)
        {
            if (!model.TransleteColumnsNames(GithubServices.Environment.ColumnNamesIds))
                return StatusCode(422);

            async Task<bool> Func(Card card)
            {
                if (await _cardsProvider.Move(card.id.ToString(), model.column_to))
                {
                    await _logsRepository.Insert(new Log()
                    {
                        CardColumn = model.column_to,
                        CardId = card.id.ToString(),
                        CardNote = card.note,
                        Operation = Operation.Move
                    });
                    return true;
                }
                return false;
            }

            return StatusCode(await UseCardsWithPattern(model.column_from, model.pattern, Func));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteModel model)
        {
            if (!model.TransleteColumnsNames(GithubServices.Environment.ColumnNamesIds))
                return StatusCode(422);

            async Task<bool> Func(Card card)
            {
                if (await _cardsProvider.Delete(card.id.ToString()))
                {
                    await _logsRepository.Insert(new Log()
                    {
                        CardColumn = model.column,
                        CardId = card.id.ToString(),
                        CardNote = card.note,
                        Operation = Operation.Delete
                    });
                    return true;
                }
                return false;
            }

            return StatusCode(await UseCardsWithPattern(model.column, model.pattern, Func));
        }

        [HttpPost("import/{projectId}")]
        public async Task<IActionResult> Import(string projectId)
        {
            bool result = true;
            var columns = await _columnsProvider.Get(projectId);
            if (columns == null)
                return StatusCode(404);
            foreach (var column in columns)
            {
                var cards = await _cardsProvider.Get(column.id.ToString());
                if (cards == null)
                    return StatusCode(500);
                foreach (var card in cards)
                {
                    Card newCard;
                    if ((newCard = await _cardsProvider.Create(GithubServices.Environment.ColumnNamesIds[Constants.BacklogName], card.note)) != null)
                    {
                        await _logsRepository.Insert(new Log()
                        {
                            CardColumn = GithubServices.Environment.ColumnNamesIds[Constants.BacklogName],
                            CardId = newCard.id.ToString(),
                            CardNote = newCard.note,
                            Operation = Operation.Import
                        });
                    }
                    result = false;
                }
            }
            return result ? StatusCode(200) : StatusCode(500);
        }
        #endregion

        #region Private methods
        private async Task<int> UseCardsWithPattern(string columnId, string pattern, Func<Card, Task<bool>> usage)
        {
            var cards = (await _cardsProvider.Get(columnId, pattern)).ToList();
            if (cards == null)
                return 500;
            if(!cards.Any())
                return 404;
            var result = true;
            foreach (var card in cards)
                result &= await usage(card);
            return result ? 200 : 500;
        }
        #endregion
    }
}
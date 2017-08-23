namespace Mocks
{
    #region Using statements
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Interfaces;
    using Models.GithubApiModels;
    #endregion

    public class MockCardsProvider : ICardsProvider
    {
        #region Implementation of ICardsProvider
        public async Task<IEnumerable<Card>> Get(string columnId)
        {
            int column;
            if ((column = this.TranslateColumn(columnId)) == -1)
                return null;
            return MockCardsContainer.Cards[column];
        }

        public async Task<IEnumerable<Card>> Get(string columnId, string pattern)
        {
            var cards = await this.Get(columnId);
            return cards.Where(c => c.note.Contains(pattern));
        }

        public async Task<bool> Move(string id, string columnId)
        {
            int column;
            if ((column=this.TranslateColumn(columnId))==-1)
                return false;

            foreach (var list in MockCardsContainer.Cards)
            {
                Card card;
                if ((card=list.FirstOrDefault(c => c.id.ToString().Equals(id)))!=null)
                {
                    list.Remove(card);
                    MockCardsContainer.Cards[column].Add(card);
                    return true;
                }
            }
            return false;
        }

        public async Task<Card> Edit(string id, string note)
        {
            foreach (var list in MockCardsContainer.Cards)
            {
                Card card;
                if ((card = list.FirstOrDefault(c => c.id.ToString().Equals(id))) != null)
                {
                    card.note = note;
                    return card;
                }
            }
            return null;
        }

        public async Task<bool> Delete(string id)
        {
            foreach (var list in MockCardsContainer.Cards)
            {
                Card card;
                if ((card = list.FirstOrDefault(c => c.id.ToString().Equals(id))) != null)
                {
                    list.Remove(card);
                    return true;
                }
            }
            return false;
        }

        public async Task<Card> Create(string columnId, string note)
        {
            int column;
            if ((column = this.TranslateColumn(columnId)) == -1)
                return null;
            var card = new Card()
            {
                id = MockCardsContainer.CardId++,
                note = note
            };
            MockCardsContainer.Cards[column].Add(card);
            return card;
        }
        #endregion

        #region Private methods
        private int TranslateColumn(string columnId)
        {
            int column;
            try
            {
                column = int.Parse(columnId);
            }
            catch
            {
                return -1;
            }
            if (!MockCardsContainer.Columns.Select(c => c.id).Contains(column))
                return -1;
            return column;
        }
        #endregion
    }
}

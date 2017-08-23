namespace Models.RestApiModels
{
    #region Using statements
    using System.Collections.Generic;

    #endregion

    public class DeleteModel : BaseApiModel
    {
        #region Properties
        public string column { get; set; }
        public string pattern { get; set; }
        #endregion

        #region Public methods
        public override bool TransleteColumnsNames(Dictionary<string, string> nameIdDictionary)
        {
            if (nameIdDictionary.ContainsKey(this.column))
                this.column = nameIdDictionary[this.column];
            return nameIdDictionary.ContainsValue(this.column);
        }
        #endregion
    }
}

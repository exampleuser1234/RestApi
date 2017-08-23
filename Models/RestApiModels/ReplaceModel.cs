namespace Models.RestApiModels
{
    #region Using statements
    using System.Collections.Generic;
    #endregion

    public class ReplaceModel : BaseApiModel
    {
        #region Properties
        public string column { get; set; }
        public string pattern { get; set; }
        public string  change_to { get; set; }
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

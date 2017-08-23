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
        public override bool CheckAndTransleteColumnsNames(Dictionary<string, string> nameIdDictionary)
        {
            if (column == null || string.IsNullOrEmpty(pattern) || change_to==null)
                return false;
            if (nameIdDictionary.ContainsKey(this.column))
                this.column = nameIdDictionary[this.column];
            return nameIdDictionary.ContainsValue(this.column);
        }
        #endregion
    }
}

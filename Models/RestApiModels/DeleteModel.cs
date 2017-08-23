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
        public override bool CheckAndTransleteColumnsNames(Dictionary<string, string> nameIdDictionary)
        {
            if (column == null || string.IsNullOrEmpty(pattern))
                return false;
            if (nameIdDictionary.ContainsKey(this.column))
                this.column = nameIdDictionary[this.column];
            return nameIdDictionary.ContainsValue(this.column);
        }
        #endregion
    }
}

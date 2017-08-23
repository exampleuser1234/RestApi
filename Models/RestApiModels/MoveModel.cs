namespace Models.RestApiModels
{
    #region Using statements
    using System.Collections.Generic;
    #endregion

    public class MoveModel:BaseApiModel
    {
        #region Properties
        public string column_from { get; set; }
        public string column_to { get; set; }
        public string pattern { get; set; }
        #endregion

        #region Public methods
        public override bool CheckAndTransleteColumnsNames(Dictionary<string, string> nameIdDictionary)
        {
            if (column_from == null || column_to==null || string.IsNullOrEmpty(pattern))
                return false;
            if (nameIdDictionary.ContainsKey(this.column_from))
                this.column_from = nameIdDictionary[this.column_from];
            if (nameIdDictionary.ContainsKey(this.column_to))
                this.column_to = nameIdDictionary[this.column_to];

            return nameIdDictionary.ContainsValue(this.column_to)&& nameIdDictionary.ContainsValue(this.column_from);
        }
        #endregion
    }
}

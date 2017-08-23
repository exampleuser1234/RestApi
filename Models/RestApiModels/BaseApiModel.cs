namespace Models.RestApiModels
{
    #region Using statements
    using System.Collections.Generic;
    #endregion

    public abstract class BaseApiModel
    {
        #region Public methods
        public abstract bool TransleteColumnsNames(Dictionary<string, string> nameIdDictionary);
        #endregion
    }
}

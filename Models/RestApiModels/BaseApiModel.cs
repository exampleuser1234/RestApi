using System;
using System.Collections.Generic;
using System.Text;

namespace Models.RestApiModels
{
    public abstract class BaseApiModel
    {
        public abstract bool TransleteColumnsNames(Dictionary<string, string> nameIdDictionary);
    }
}

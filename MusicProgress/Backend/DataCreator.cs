using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicProgress.Backend
{
    public abstract class DataCreator
    {
        // fabric method
        public abstract DataChunk FactoryMethod();
    }

    public class UpDownCreator : DataCreator
    {
        public override DataChunk FactoryMethod()
        {
            return new UpDownData();
        }
    }

    public class SearchToneCreator : DataCreator
    {
        public override DataChunk FactoryMethod()
        {
            return new SearchToneData();
        }
    
    }

    public class DefineToneCreator : DataCreator
    {
        public override DataChunk FactoryMethod()
        {
            return new DefineToneData();
        }
    
    }


}
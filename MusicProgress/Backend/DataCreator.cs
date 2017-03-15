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
        // fabric method with parameter
        public abstract DataChunk FactoryMethod_2(DateTime _date);
    }

    public class UpDownCreator : DataCreator
    {
        public override DataChunk FactoryMethod()
        {
            return new UpDownData();
        }
        public override DataChunk FactoryMethod_2(DateTime _date)
        {
            return new UpDownData(_date);
        }
    }

    public class SearchToneCreator : DataCreator
    {
        public override DataChunk FactoryMethod()
        {
            return new SearchToneData();
        }
        public override DataChunk FactoryMethod_2(DateTime _date)
        {
            return new SearchToneData(_date);
        }
    
    }

    public class DefineToneCreator : DataCreator
    {
        public override DataChunk FactoryMethod()
        {
            return new DefineToneData();
        }
        public override DataChunk FactoryMethod_2(DateTime _date)
        {
            return new DefineToneData(_date);
        }
    
    }


}
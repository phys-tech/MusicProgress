using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicProgress.Backend
{
    //! Parent class for Factory method
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

    public class UnknownCreator : DataCreator
    {
        public override DataChunk FactoryMethod()
        {
            return new UnknownData();
        }

        public override DataChunk FactoryMethod_2(DateTime _date)
        {
            return new UnknownData(_date);
        }
    }

    //*****************************************************************
    //! Second level of inheritance in Factory method

    public class Search37Creator : SearchToneCreator
    {
        public override DataChunk FactoryMethod()
        {
            return new Search37Tone();
        }
        public override DataChunk FactoryMethod_2(DateTime _date)
        {
            return new Search37Tone(_date);
        }    
    }

    public class Sequence2NotesCreator : DefineToneCreator
    {
        public override DataChunk FactoryMethod()
        {
            return new Sequence2Notes();
        }
        public override DataChunk FactoryMethod_2(DateTime _date)
        {
            return new Sequence2Notes(_date);
        }
    }

    public class Define37NotesCreator : DefineToneCreator
    {
        public override DataChunk FactoryMethod()
        {
            return new Define37Tone();
        }
        public override DataChunk FactoryMethod_2(DateTime _date)
        {
            return new Define37Tone(_date);
        }
    }

    public class Sequence2N37TCreator : DefineToneCreator
    {
        public override DataChunk FactoryMethod()
        {
            return new Sequence2N37Tones();
        }
        public override DataChunk FactoryMethod_2(DateTime _date)
        {
            return new Sequence2N37Tones(_date);
        }
    }


}
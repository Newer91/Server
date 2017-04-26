using BandD.Serwis.Model.DictionarySerivce;

namespace BandD.Serwis.Model
{
    public abstract class BaseModel
    {
        public DictionariesServiceClient service = new DictionariesServiceClient();
    }
}

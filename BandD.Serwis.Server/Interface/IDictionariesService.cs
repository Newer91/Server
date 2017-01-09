using BandD.Serwis.Domain;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace BandD.Serwis.Server.Interface
{
    [ServiceContract]
    public interface IDictionariesService
    {
        #region Users

        [OperationContract]
        bool Autorauthorization(string password, string userName);

        [OperationContract]
        List<User> getDataFromUser();

        #endregion

        #region OrderStatus

        [OperationContract]
        List<SlOrderStat> getDataFromSlOrderStat(string name, bool? activity);

        [OperationContract]
        void removeElementFromSlOrderStat(Guid id);

        [OperationContract]
        void addElementToSlOrderStat(SlOrderStat element);

        [OperationContract]
        void updateElementSlOrderStat(SlOrderStat element);


        #endregion
    }
}

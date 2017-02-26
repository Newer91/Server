using BandD.Serwis.ClassViewModel.Dictionaries;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace BandD.Serwis.SerwisISS.Interface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDictionariesService" in both code and config file together.
    [ServiceContract]
    public interface IDictionariesService
    {
        #region Users

        [OperationContract]
        bool Autorauthorization(string password, string userName);

        [OperationContract]
        List<UserView> getDataFromUser(string name, bool? status, string role);

        [OperationContract]
        void removeElementFromUsers(Guid id);

        [OperationContract]
        void addElementToUsers(UserView element);

        [OperationContract]
        void updateElementUsers(UserView element);

        #endregion

        #region OrderStatus

        [OperationContract]
        List<SlOrderStatView> getDataFromSlOrderStat(string name, bool? activity);

        [OperationContract]
        void removeElementFromSlOrderStat(Guid id);

        [OperationContract]
        void addElementToSlOrderStat(SlOrderStatView element);

        [OperationContract]
        void updateElementSlOrderStat(SlOrderStatView element);


        #endregion

        #region CarrierStatus

        [OperationContract]
        List<SlCarriersStatView> getDataFromSlCarrierStat(string name, bool? carrierStatus);
        [OperationContract]
        void updateElementSlCarrierStat(SlCarriersStatView stats);
        [OperationContract]
        void addElementToSlCarrierStat(SlCarriersStatView stats);
        [OperationContract]
        void removeElementFromSlCarrierStat(Guid statsId);

        #endregion
    }
}

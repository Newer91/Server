using BandD.Serwis.ClassViewModel.Dictionaries;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        List<UserView> GetDataFromUser(string name, bool? status, Guid? role);

        [OperationContract]
        void RemoveElementFromUsers(Guid id);

        [OperationContract]
        void AddElementToUsers(UserView element);

        [OperationContract]
        void UpdateElementUsers(UserView element);

        #endregion

        #region OrderStatus

        [OperationContract]
        List<SlOrderStatView> GetDataFromSlOrderStat(string name, bool? activity);

        [OperationContract]
        void RemoveElementFromSlOrderStat(Guid id);

        [OperationContract]
        void AddElementToSlOrderStat(SlOrderStatView element);

        [OperationContract]
        void UpdateElementSlOrderStat(SlOrderStatView element);

        #endregion

        #region CarrierStatus

        [OperationContract]
        List<SlCarriersStatView> GetDataFromSlCarrierStat(string name, bool? carrierStatus);
        [OperationContract]
        void UpdateElementSlCarrierStat(SlCarriersStatView stats);
        [OperationContract]
        void AddElementToSlCarrierStat(SlCarriersStatView stats);
        [OperationContract]
        void RemoveElementFromSlCarrierStat(Guid statsId);

        #endregion

        #region Roles

        [OperationContract]
        ObservableCollection<SlRoleView> GetAllActiveRoles();

        #endregion
    }
}

using BandD.Serwis.ClassViewModel.Dictionaries;
using ClassViewModel.Dictionaries;
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
        bool RemoveElementFromUsers(Guid id);

        [OperationContract]
        bool AddElementToUsers(UserView element);

        [OperationContract]
        bool UpdateElementUsers(UserView element);

        #endregion

        #region OrderStatus

        [OperationContract]
        List<SlOrderStatView> GetDataFromSlOrderStat(string name, bool? activity);

        [OperationContract]
        bool RemoveElementFromSlOrderStat(Guid id);

        [OperationContract]
        bool AddElementToSlOrderStat(SlOrderStatView element);

        [OperationContract]
        bool UpdateElementSlOrderStat(SlOrderStatView element);

        #endregion

        #region CarrierStatus

        [OperationContract]
        List<SlCarriersStatView> GetDataFromSlCarrierStat(string name, bool? carrierStatus);

        [OperationContract]
        bool UpdateElementSlCarrierStat(SlCarriersStatView stats);

        [OperationContract]
        bool AddElementToSlCarrierStat(SlCarriersStatView stats);

        [OperationContract]
        bool RemoveElementFromSlCarrierStat(Guid statsId);

        #endregion

        #region Roles

        [OperationContract]
        ObservableCollection<SlRoleView> GetAllRoles(bool isAll);

        [OperationContract]
        ObservableCollection<SlRoleView> GetDataFromRole(string name, bool? status);

        [OperationContract]
        bool RemoveElementFromRole(Guid id);

        [OperationContract]
        bool UpdateElementSlRole(SlRoleView role);

        [OperationContract]
        bool AddElementToSlRole(SlRoleView role);

        #endregion

        #region Address

        [OperationContract]
        ObservableCollection<AddressesView> GetDataFromAddress(string city, string street, string number);

        [OperationContract]
        bool RemoveElementFromAddress(Guid id);

        [OperationContract]
        bool AddElementToAddress(AddressesView element);

        [OperationContract]
        bool UpdateElementAddress(AddressesView element);

        #endregion

        #region Client

        [OperationContract]
        ObservableCollection<ClientView> GetDataFromClient(string shortName, int nip, int regon, bool? value);

        [OperationContract]
        bool RemoveElementFromClient(Guid id);

        #endregion
    }
}

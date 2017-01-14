﻿using BandD.Serwis.Domain;
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
        List<User> getDataFromUser(string name, bool? status, string role);

        [OperationContract]
        void removeElementFromUsers(Guid id);

        [OperationContract]
        void addElementToUsers(User element);

        [OperationContract]
        void updateElementUsers(User element);

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

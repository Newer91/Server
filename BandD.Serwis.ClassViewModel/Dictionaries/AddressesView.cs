﻿using System;
using System.Runtime.Serialization;

namespace BandD.Serwis.ClassViewModel.Dictionaries
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class AddressesView
    {
        public Guid AddressId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public int PostCode { get; set; }
        public bool IsCompanyAddres { get; set; }
        public bool IsDeliveryAddres { get; set; }
        public string ClientName { get; set; }

        public AddressesView CreateAddresView()
        {
            throw new NotImplementedException();
        }       
    }
}